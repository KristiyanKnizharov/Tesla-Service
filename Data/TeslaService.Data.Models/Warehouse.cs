namespace TeslaService.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Warehouse
    {
        public Warehouse()
        {
            this.Parts = new HashSet<Part>();
        }

        [Key]
        public int Id { get; set; }

        public virtual ICollection<Part> Parts { get; set; }
    }
}
