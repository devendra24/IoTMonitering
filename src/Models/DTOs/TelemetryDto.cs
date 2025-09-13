namespace IoTMonitoring.Models.DTOs
{
    public class TelemetryDto
    {
        public int DeviceId { get; set; }
        public double Temperature { get; set; }
        public double Humidity { get; set; }
    }

}
