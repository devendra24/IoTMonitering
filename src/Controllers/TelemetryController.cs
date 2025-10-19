﻿using System.Security.Claims;
using IoTMonitoring.Data;
using IoTMonitoring.Hubs;
using IoTMonitoring.Models;
using IoTMonitoring.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace IoTMonitoring.Controllers
{
    [Route("api/devices/{deviceId}/[controller]")]
    [ApiController]
    public class TelemetryController : ControllerBase
    {
        private AppDbContext _context;
        private IHubContext<TelemetryHub> _hub;
        private int maxTelemetry =20;

        public TelemetryController(AppDbContext contex,IHubContext<TelemetryHub> hub)
        {
            _context = contex;
            _hub = hub;
        }

        [HttpPost]
        public async Task<IActionResult> AddTelemetry(string devicekwy, TelemetryCreateDto dto)
        {
            var userId = devicekwy;

            var device = await _context.Devices
                .FirstOrDefaultAsync(d => d.DeviceKey == devicekwy);

            if (device == null) return NotFound("Device not found or not owned by user");

            var telemetry = new Telemetry
            {
                DeviceId = device.Id,
                Temperature = dto.Temperature,
                Humidity = dto.Humidity,
                Timestamp = DateTime.UtcNow,
            };

            _context.Telemetries.Add(telemetry);
            await _context.SaveChangesAsync();

            await _hub.Clients.Group($"device-{devicekwy}").SendAsync("ReceiveTelemetry", new
            {
                DeviceId = device.Id,
                telemetry.Temperature,
                telemetry.Humidity,
                telemetry.Timestamp
            });

            return Ok("Telemetry recorded and broadcasted");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TelemetryReadDto>>> GetTelemetry(string deviceKey,int page)
        {

            // ensure the device belongs to this user
            var device = await _context.Devices
                .FirstOrDefaultAsync(d => d.DeviceKey == deviceKey);

            if (device == null) return NotFound("Device not found or not owned by user");

            var telemetry = await _context.Telemetries
                .Where(t => t.DeviceId == device.Id)
                .OrderByDescending(t => t.Timestamp)
                .Skip((page-1)*maxTelemetry)
                .Take(maxTelemetry)
                .Select(t => new TelemetryReadDto
                {
                    Temperature = t.Temperature,
                    Humidity = t.Humidity,
                    Timestamp = t.Timestamp
                })
                .ToListAsync();

            return Ok(telemetry);
        }
    }
}
