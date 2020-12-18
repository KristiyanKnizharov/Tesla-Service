namespace TeslaService.Services.Data.Dto
{
    using TeslaService.Data.Models.Enum;

    public class BatteryDto
    {
        public string Id { get; set; }
        public BatteryStatus Status { get; set; }

        public string SoftwareVersion { get; set; }

        public int Mileage { get; set; }

        public int HorsePower { get; set; }

        public int KilowattHour { get; set; }

        public int Range { get; set; }
    }
}
