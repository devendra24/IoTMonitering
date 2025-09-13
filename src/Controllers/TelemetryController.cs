using System.Security.Claims;
using IoTMonitoring.Data;
using IoTMonitoring.Models;
using IoTMonitoring.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IoTMonitoring.Controllers
{
    [Route("api/devices/{deviceId}/[controller]")]
    [ApiController]
    [Authorize]
    public class TelemetryController : ControllerBase
    {
        private AppDbContect _context;

        public TelemetryController(AppDbContect contex)
        {
            _context = contex;
        }

        [HttpPost]
        public async Task<IActionResult> AddTelemetry(int deviceId, TelemetryCreateDto dto)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var device = await _context.Devices
                .FirstOrDefaultAsync(d => d.Id == deviceId && d.UserId == userId);

            if (device == null) return NotFound("Device not found or not owned by user");

            var telemetry = new Telemetry
            {
                DeviceId = deviceId,
                Temperature = dto.Temperature,
                Humidity = dto.Humidity,
                Timestamp = DateTime.UtcNow,
            };

            _context.Telemetries.Add(telemetry);
            await _context.SaveChangesAsync();

            return Ok("Telemetry saved");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TelemetryReadDto>>> GetTelemetry(int deviceId)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            // ensure the device belongs to this user
            var device = await _context.Devices
                .FirstOrDefaultAsync(d => d.Id == deviceId && d.UserId == userId);

            if (device == null) return NotFound("Device not found or not owned by user");

            var telemetry = await _context.Telemetries
                .Where(t => t.DeviceId == deviceId)
                .OrderByDescending(t => t.Timestamp)
                .Take(20) // last 20 entries
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
