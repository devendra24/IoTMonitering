namespace IoTMonitoring.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserID { get; set; }
        public ICollection<Device> Devices { get; set; } = new List<Device>();
    }
}
