namespace IoTMonitoring.Models.DTOs
{
    public class DeviceDto
    {
        public class DeviceCreateDto
        {
            public string Name { get; set; } = string.Empty;
            public DeviceType Type { get; set; } = DeviceType.Unknown; // e.g., Sensor, Actuator
        }

        public class DeviceUpdateDto
        {
            public string Name { get; set; } = string.Empty;
            public DeviceType Type { get; set; } = DeviceType.Unknown;
        }

        public class DeviceReadDto
        {
            public int Id { get; set; }
            public string Name { get; set; } = string.Empty;
            public DeviceType Type { get; set; } = DeviceType.Unknown;
        }
    }
}
