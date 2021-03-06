﻿namespace TeslaService.Services.Data.Dto
{
    using System;

    using TeslaService.Data.Models;
    using TeslaService.Data.Models.Enum;

    public class VehicleDto
    {
        public string Id { get; set; }

        public VehicleModel VehicleModel { get; set; }

        public VehicleType VehicleType { get; set; }

        public string ImageURL { get; set; }

        public DateTime DateOfPurchase { get; set; }

        public string BatteryId { get; set; }

        public Battery Battery { get; set; }

        public string Description { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public string InsuranceId { get; set; }

        public virtual Insurance Insurance { get; set; }

        public int ServiceId { get; set; }

        public virtual Service Service { get; set; }
    }
}
