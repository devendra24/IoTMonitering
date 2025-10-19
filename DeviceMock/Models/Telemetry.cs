
namespace DeviceMock.Models
{
    public class Telemetry
    {
        public string DeviceId { get; set; }
        public string DeviceName { get; internal set; }
        public double Temperature { get; internal set; }
        public double Humidity { get; internal set; }
        public DateTime Timestamp { get; internal set; }
    }
}
