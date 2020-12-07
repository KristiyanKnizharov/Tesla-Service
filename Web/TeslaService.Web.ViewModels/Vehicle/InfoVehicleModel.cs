namespace TeslaService.Web.ViewModels.Vehicle
{
    using System.ComponentModel.DataAnnotations;

    using TeslaService.Data.Models.Enum;

    public class InfoVehicleModel
    {
        [Required]
        public VehicleModel VehicleModel { get; set; }

        [Required]
        public VehicleType VehicleType { get; set; }

        [Required]
        public string ImageURL { get; set; }
    }
}
