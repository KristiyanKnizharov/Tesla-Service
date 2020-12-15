namespace TeslaService.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Warehouse
    {
        public Warehouse()
        {
            this.Parts = new HashSet<Part>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Location { get; set; }

        public int ServiceId { get; set; }

        public Service Service { get; set; }

        public virtual ICollection<Part> Parts { get; set; }
    }
}
