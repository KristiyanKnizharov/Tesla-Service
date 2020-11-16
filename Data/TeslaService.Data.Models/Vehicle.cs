namespace TeslaService.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using TeslaService.Data.Common.Models;
    using TeslaService.Data.Models.Enum;

    public class Vehicle : BaseModel<int>
    {
        public Vehicle()
        {
            this.RepairedPart = new HashSet<Part>();
        }

        [Required]
        public VehicleModel VehicleModel { get; set; }

        [Required]
        public VehicleType VehicleType { get; set; }

        [Required]
        public string ImageURL { get; set; }

        [Required]
        public DateTime DateOfPurchase { get; set; }

        [Required]
        [MaxLength(20)]
        public string SoftwareVersion { get; set; }

        [Required]
        [MaxLength(10)]
        public double Mileage { get; set; }

        [Required]
        [MaxLength(5)]
        public int HorsePower { get; set; }

        [Required]
        [MaxLength(5)]
        public int KilowattHour { get; set; }

        [Required]
        public int BatteryId { get; set; }

        public Battery Battery { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Required]
        public int InsuranceId { get; set; }

        public virtual Insurance Insurance { get; set; }

        public virtual ICollection<Part> RepairedPart { get; set; }

        [Required]
        public int ServiceId { get; set; }

        public virtual Service Service { get; set; }
    }
}
