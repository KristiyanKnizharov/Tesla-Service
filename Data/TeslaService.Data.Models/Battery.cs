namespace TeslaService.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using TeslaService.Data.Models.Enum;

    public class Battery
    {
        public int Id { get; set; }

        public BatteryStatus Status { get; set; }

        [Required]
        [MaxLength(5)]
        public int Range { get; set; }
    }
}
