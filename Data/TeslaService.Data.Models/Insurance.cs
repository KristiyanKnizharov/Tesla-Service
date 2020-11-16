namespace TeslaService.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Insurance
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(30)]
        public string VinNumber { get; set; }

        public DateTime DateOfStart { get; set; }

        public DateTime DateOfEnd { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }
    }
}
