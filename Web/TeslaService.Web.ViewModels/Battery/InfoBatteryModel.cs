namespace TeslaService.Web.ViewModels.Battery
{
    using System.ComponentModel.DataAnnotations;

    using TeslaService.Data.Models.Enum;

    public class InfoBatteryModel
    {
        public string Id { get; set; }

        public BatteryStatus Status { get; set; }

        [Required]
        [MaxLength(36)]
        public string SoftwareVersion { get; set; }

        [Required]
        [Range(1, 999999999)]
        public int Mileage { get; set; }

        [Required]
        [Range(1, 9999)]
        public int HorsePower { get; set; }

        [Required]
        [Range(1, 9999)]
        public int KilowattHour { get; set; }

        [Required]
        [Range(1, 9999)]
        public int Range { get; set; }
    }
}
