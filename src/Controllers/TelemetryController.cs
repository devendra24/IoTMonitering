using IoTMonitoring.Data;
using IoTMonitoring.Models;
using IoTMonitoring.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IoTMonitoring.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TelemetryController : ControllerBase
    {
        private AppDbContect _context;

        public TelemetryController(AppDbContect contex)
        {
            _context = contex;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendTelemetry(TelemetryDto dto)
        {
            var device = await _context.Devices.FindAsync(dto.DeviceId);

            if (device == null)
                return NotFound("Device not found");

            var telemetry = new Telemetry
            {
                DeviceId = dto.DeviceId,
                Tempreture = dto.Temperature,
                Humidity = dto.Humidity,
                Timestamp = DateTime.UtcNow,
            };

            _context.Telemetries.Add(telemetry);
            await _context.SaveChangesAsync();

            return Ok("Telemetry saved");
        }

        [HttpGet("{deviceId}")]
        public async Task<IActionResult> GetTelemetry(int deviceId)
        {
            var data = await _context.Telemetries
                .Where(t => t.DeviceId == deviceId)
                .OrderByDescending(t => t.Timestamp)
                .Take(50) // latest 50 readings
                .ToListAsync();

            return Ok(data);
        }
    }
}
