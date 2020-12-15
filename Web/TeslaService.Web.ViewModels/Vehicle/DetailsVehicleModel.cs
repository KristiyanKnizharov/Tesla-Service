namespace TeslaService.Web.ViewModels.Vehicle
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using TeslaService.Data.Models.Enum;
    using TeslaService.Web.ViewModels.Battery;

    public class DetailsVehicleModel
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public VehicleModel VehicleModel { get; set; }

        [Required]
        public VehicleType VehicleType { get; set; }

        [Required]
        public string ImageURL { get; set; }

        [Required]
        public DateTime DateOfPurchase { get; set; }

        [Required]
        public string BatteryId { get; set; }

        public InfoBatteryModel Battery { get; set; }

        public string InsuranceId { get; set; }

        [Required]
        public int ServiceId { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }
    }
}
