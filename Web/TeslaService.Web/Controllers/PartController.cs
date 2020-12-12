namespace TeslaService.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using TeslaService.Services.Data;
    using TeslaService.Web.ViewModels.Part;

    public class PartController : BaseController
    {
        private readonly PartService partService;

        public PartController(PartService partService)
        {
            this.partService = partService;
        }

        [HttpPost]
        [Authorize]
        public IActionResult Add(string name)
        {
            this.partService.AddPartAsync(name);
            var parts = this.partService.GetAllParts();
            return this.View(parts);
        }

        [Authorize]
        public IActionResult Create()
        {
            var viewModel = new CreatePartModel() { };
            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(string name, double price)
        {
            if (!this.partService.IsItPartCreated(name))
            {
                this.partService.CreatePartAsync(name, price);
            }

            return this.Redirect("/Warehouse/All");
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddQuantity(string partName)
        {
            if (this.partService.IsItPartCreated(partName))
            {
                this.partService.AddPartAsync(partName);
            }

            return this.Redirect("/Warehouse/All");
        }
    }
}
