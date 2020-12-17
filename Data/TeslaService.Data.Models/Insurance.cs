namespace TeslaService.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Insurance
    {
        public Insurance()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        [MaxLength(30)]
        public string VinNumber { get; set; }

        public string DateOfStart { get; set; }

        public string DateOfEnd { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }
    }
}
