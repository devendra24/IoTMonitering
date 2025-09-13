using System.Security.Claims;
using IoTMonitoring.Data;
using IoTMonitoring.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static IoTMonitoring.Models.DTOs.DeviceDto;

namespace IoTMonitoring.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class DeviceController : ControllerBase
    {
        private AppDbContect _context;

        public DeviceController(AppDbContect contex)
        {
            _context = contex;
        }

        [HttpPost]
        public async Task<ActionResult<DeviceReadDto>> CreateDevice(DeviceCreateDto dto)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var device = new Device
            {
                Name = dto.Name,
                DeviceKey = Guid.NewGuid().ToString(),
                UserId = userId,
                Type = dto.Type,
            };

            _context.Devices.Add(device);
            await _context.SaveChangesAsync();

            return new DeviceReadDto
            {
                Id = device.Id,
                Name = device.Name,
                Type = device.Type,
            };
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeviceReadDto>>> GetDevices()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var devices = await _context.Devices
                .Where(x => x.UserId == userId)
                .ToListAsync();

            return devices.Select(d => new DeviceReadDto
            {
                Id = d.Id,
                Name = d.Name,
                Type = d.Type,
            }).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DeviceReadDto>> GetDevice(int id)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var device = await _context.Devices
                .FirstOrDefaultAsync(d => d.Id == id && d.UserId == userId);

            if (device == null) return NotFound();

            return new DeviceReadDto
            {
                Id = device.Id,
                Name = device.Name,
                Type = device.Type
            };
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDevice(int id, DeviceUpdateDto dto)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var device = await _context.Devices
                .FirstOrDefaultAsync(d => d.Id == id && d.UserId == userId);

            if (device == null) return NotFound();

            device.Name = dto.Name;
            device.Type = dto.Type;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDevice(int id)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var device = await _context.Devices
                .FirstOrDefaultAsync(d => d.Id == id && d.UserId == userId);

            if (device == null) return NotFound();

            _context.Devices.Remove(device);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
