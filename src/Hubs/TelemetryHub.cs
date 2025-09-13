using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace IoTMonitoring.Hubs
{
    [Authorize]
    public class TelemetryHub :Hub
    {
        public override async Task OnConnectedAsync()
        {
            var userId = Context.User?.Identity?.Name ?? "Unknown";
            await Clients.Caller.SendAsync("Connected", $"Welcome {userId}, you are now connected to TelemetryHub!");
            await base.OnConnectedAsync();
        }

        public async Task JoinDeviceGroup(string deviceId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, $"device-{deviceId}");
            await Clients.Caller.SendAsync("JoinedGroup", $"Joined device {deviceId} telemetry group");
        }
    }
}
