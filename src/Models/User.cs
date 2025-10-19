namespace IoTMonitoring.Models
{
    public class User
    {
        public int Id { get; set; }
        public ICollection<Device> Devices { get; set; } = new List<Device>();
    }
}
