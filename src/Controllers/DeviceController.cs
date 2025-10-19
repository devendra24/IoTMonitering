using System.Security.Claims;
using IoTMonitoring.Data;
using IoTMonitoring.Migrations;
using IoTMonitoring.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static IoTMonitoring.Models.DTOs.DeviceDto;

namespace IoTMonitoring.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeviceController : ControllerBase
    {
        private AppDbContext _context;

        public DeviceController(AppDbContext contex)
        {
            _context = contex;
        }

        
        [HttpPost]
        public async Task<IActionResult> CreateDevice(DeviceCreateDto dto)
        {
            var userId = dto.userID;
            var user = _context.Users.FirstOrDefault(x=>x.UserID == userId);
            var key = Guid.NewGuid().ToString();
            var device = new Device
            {
                Name = dto.Name,
                DeviceKey = key,
                UserId = user.Id,
                Type = dto.Type,
            };

            _context.Devices.Add(device);
            await _context.SaveChangesAsync();

            return Ok(new 
            {
                key = key,
                Name = device.Name,
                Type = device.Type,
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetDevices(string userID)
        {
            var user = _context.Users.FirstOrDefault(x => x.UserID == userID);

            var devices = await _context.Devices
                .Where(x => x.UserId == user.Id)
                .ToListAsync();

            return Ok(devices.Select(d => new
            {
                Id = d.DeviceKey,
                Name = d.Name,
                Type = d.Type,
            }).ToList());
        }

        [HttpGet("{key}")]
        public async Task<ActionResult<DeviceReadDto>> GetDevice(string key)
        {
            
            var device = await _context.Devices
                .FirstOrDefaultAsync(d => d.DeviceKey == key);

            if (device == null) return NotFound();

            return new DeviceReadDto
            {
                Id = device.Id,
                Name = device.Name,
                Type = device.Type
            };
        }

        [HttpPut("{key}")]
        public async Task<IActionResult> UpdateDevice(string key, DeviceUpdateDto dto)
        {
            var device = await _context.Devices
                .FirstOrDefaultAsync(d => d.DeviceKey == key);

            if (device == null) return NotFound();

            device.Name = dto.Name;
            device.Type = dto.Type;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{key}")]
        public async Task<IActionResult> DeleteDevice(string key)
        {
            var device = await _context.Devices
                .FirstOrDefaultAsync(d => d.DeviceKey == key);

            if (device == null) return NotFound();

            _context.Devices.Remove(device);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
