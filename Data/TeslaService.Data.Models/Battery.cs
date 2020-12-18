namespace TeslaService.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using TeslaService.Data.Models.Enum;

    public class Battery
    {
        public Battery()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        public BatteryStatus Status { get; set; }

        [Required]
        [MaxLength(36)]
        public string SoftwareVersion { get; set; }

        [Required]
        [MaxLength(10)]
        public int Mileage { get; set; }

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
