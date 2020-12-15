namespace TeslaService.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using TeslaService.Data.Models.Enum;

    public class Vehicle
    {
        public Vehicle()
        {
            this.Id = Guid.NewGuid().ToString();
            this.RepairedParts = new HashSet<Part>();
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

        [ForeignKey(nameof(Battery))]
        public string BatteryId { get; set; }

        public Battery Battery { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        [ForeignKey(nameof(ApplicationUser))]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public string InsuranceId { get; set; }

        public virtual Insurance Insurance { get; set; }

        [ForeignKey(nameof(Service))]
        public int ServiceId { get; set; }

        public virtual Service Service { get; set; }

        public virtual ICollection<Part> RepairedParts { get; set; }
    }
}
