namespace TeslaService.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using TeslaService.Data.Models.Enum;

    public class Vehicle
    {
        public Vehicle()
        {
            this.Id = Guid.NewGuid().ToString();
            this.RepairedPart = new HashSet<Part>();
        }

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

        public Battery Battery { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int? InsuranceId { get; set; }

        public virtual Insurance Insurance { get; set; }

        public virtual ICollection<Part> RepairedPart { get; set; }

        [Required]
        public int ServiceId { get; set; }

        public virtual Service Service { get; set; }
    }
}
