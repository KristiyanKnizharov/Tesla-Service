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
            var viewModel = new CreatePartModel();
            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreatePartModel cpm)
        {
            try
            {
                if (!this.partService.IsItPartWithModelCreated(cpm.Name, cpm.VehicleModel))
                {
                    await this.partService.CreatePartAsync(cpm);
                }
            }
            catch (Exception message)
            {
                return this.Problem(message.ToString());
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

        [HttpPost]
        [Authorize]
        public IActionResult RemoveQuantity(string partName)
        {
            if (this.partService.IsItPartCreated(partName))
            {
                this.partService.RemovePartAsync(partName);
            }

            return this.Redirect("/Warehouse/All");
        }
    }
}
