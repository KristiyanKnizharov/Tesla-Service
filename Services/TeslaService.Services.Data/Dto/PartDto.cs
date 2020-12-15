namespace TeslaService.Services.Data.Dto
{
    using TeslaService.Data.Models.Enum;

    public class PartDto
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

        public VehicleModel VehicleModel { get; set; }
    }
}
