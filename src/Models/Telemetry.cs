namespace IoTMonitoring.Models
{
    public class Telemetry
    {
        public int Id { get; set; }
        public int DeviceId { get; set; }
        public Device? Device { get; set; }
        public double Tempreture { get; set; }
        public double Humidity { get; set; }
        public DateTime Timestamp {  get; set; } = DateTime.UtcNow;
    }
}
