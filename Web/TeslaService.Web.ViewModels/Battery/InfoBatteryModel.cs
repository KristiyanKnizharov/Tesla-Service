namespace TeslaService.Web.ViewModels.Battery
{
    using System.ComponentModel.DataAnnotations;

    using TeslaService.Data.Models.Enum;

    public class InfoBatteryModel
    {
        public string Id { get; set; }
        public BatteryStatus Status { get; set; }

        [Required]
        [MaxLength(20)]
        public string SoftwareVersion { get; set; }

        [Required]
        [MaxLength(10)]
        public double Mileage { get; set; }

        [Required]
        [MaxLength(5)]
        public int HorsePower { get; set; }

        [Required]
        [MaxLength(5)]
        public int KilowattHour { get; set; }

        [Required]
        [MaxLength(5)]
        public int Range { get; set; }
    }
}
