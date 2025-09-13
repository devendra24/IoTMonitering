using IoTMonitoring.Models;
using Microsoft.EntityFrameworkCore;

namespace IoTMonitoring.Data
{
    public class AppDbContect : DbContext
    {
        public AppDbContect(DbContextOptions<AppDbContect> options):base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Telemetry> Telemetries { get; set; }
    }
}
