﻿namespace TeslaService.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Position { get; set; }

        [Required]
        public string ImageURL { get; set; }

        public int ServiceId { get; set; }

        public virtual Service Service { get; set; }
    }
}
