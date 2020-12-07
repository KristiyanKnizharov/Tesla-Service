namespace TeslaService.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using TeslaService.Services.Data;

    public class PartController : BaseController
    {
        private readonly PartService partService;

        public PartController(PartService partService)
        {
            this.partService = partService;
        }

        [HttpPost]
        [Authorize]
        public IActionResult Add(string name, double price)
        {
            this.partService.AddPartAsync(name);
            var parts = this.partService.GetAllParts();
            return this.View(parts);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(string name, double price)
        {
            if (!this.partService.IsItPartCreated(name))
            {
                this.partService.CreatePartAsync(name, price);
            }

            this.partService.AddPartAsync(name);
            var parts = this.partService.GetAllParts();
            return this.View(parts);
        }
    }
}
