namespace TeslaService.Web.ViewModels.Vehicle
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class CreateVehicleModel : InfoVehicleModel
    {
        [Required]
        public DateTime DateOfPurchase { get; set; }

        [Required]
        public string BatteryId { get; set; }

        [Required]
        public string InsuranceId { get; set; }

        [Required]
        public int ServiceId { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }
    }
}
