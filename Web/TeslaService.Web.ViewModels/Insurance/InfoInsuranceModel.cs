﻿namespace TeslaService.Web.ViewModels.Insurance
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class InfoInsuranceModel
    {
        public InfoInsuranceModel()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        [Key]
        public string Id { get; set; }

        [MaxLength(30)]
        public string VinNumber { get; set; }

        public DateTime DateOfStart { get; set; }

        public DateTime DateOfEnd { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }
    }
}
