namespace TeslaService.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using TeslaService.Data.Models.Enum;

    public class Part
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public VehicleModel VehicleModel { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
