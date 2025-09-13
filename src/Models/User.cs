namespace IoTMonitoring.Models
{
    public enum Role
    {
        User,
        Admin
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;

        public Role Role  { get; set; } = Role.User;
    }
}
