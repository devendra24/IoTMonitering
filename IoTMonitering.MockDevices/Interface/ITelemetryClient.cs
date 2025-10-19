using DeviceMock.Models;

namespace DeviceMock.Interface
{
    internal interface ITelemetryClient
    {
        bool IsDeviceRegisterd(string deviceId);

        Task SendTelemtryAsync(Telemetry telemetry);
    }
}
