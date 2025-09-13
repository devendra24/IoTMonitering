using System.Security.Claims;
using IoTMonitoring.Data;
using IoTMonitoring.Models;
using IoTMonitoring.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IoTMonitoring.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class DeviceController : ControllerBase
    {
        private AppDbContect _contex;

        public DeviceController(AppDbContect contex)
        {
            _contex = contex;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(DeviceRegisterDto dto)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var device = new Device
            {
                Name = dto.Name,
                DeviceKey = Guid.NewGuid().ToString(),
                UserId = userId,
            };

            _contex.Devices.Add(device);
            await _contex.SaveChangesAsync();

            return Ok(new { device.Id, device.Name, device.DeviceKey });
        }

        [HttpGet("my-devices")]
        public async Task<IActionResult> GetMyDevices()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var devices = await _contex.Devices
                .Where(x => x.UserId == userId)
                .ToListAsync();

            return Ok(devices);
        }
    }
}
