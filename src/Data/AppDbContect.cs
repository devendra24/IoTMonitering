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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Devices)
                .WithOne(d => d.User)
                .HasForeignKey(d => d.UserId);

            modelBuilder.Entity<Device>()
                .HasMany<Telemetry>()
                .WithOne(t => t.Device)
                .HasForeignKey(t => t.DeviceId);
        }
    }
}
