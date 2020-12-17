namespace TeslaService.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using TeslaService.Services.Data;

    public class WarehouseController : BaseController
    {
        private readonly WarehouseService warehouseService;
        private readonly PartService partService;

        public WarehouseController(
            WarehouseService warehouseService,
            PartService partService)
        {
            this.warehouseService = warehouseService;
            this.partService = partService;
        }

        public IActionResult All()
        {
            var parts = this.partService.GetAllParts();
            return this.View(parts);
        }
    }
}
