namespace TeslaService.Web.ViewModels.Part
{
    using System.ComponentModel.DataAnnotations;

    using TeslaService.Data.Models.Enum;

    public class CreatePartModel
    {
        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [Range(1, 100000)]
        public double Price { get; set; }

        [Required]
        [Range(0, 1000)]
        public int Quantity { get; set; }

        [Required]
        public VehicleModel VehicleModel { get; set; }
    }
}
