namespace TeslaService.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using TeslaService.Data.Common.Models;

    public class Part : BaseModel<int>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
