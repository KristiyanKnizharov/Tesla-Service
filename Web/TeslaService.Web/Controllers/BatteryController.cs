namespace TeslaService.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;
    using TeslaService.Services.Data.Contracts;
    using TeslaService.Web.ViewModels.Battery;
    public class BatteryController : BaseController
    {
        private readonly IBatteryService batteryService;

        public BatteryController(IBatteryService batteryService)
        {
            this.batteryService = batteryService;
        }

        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(InfoBatteryModel ibm)
        {
            this.batteryService.CreateBatteryAsync(ibm);
            return this.Redirect("/Battery/All");
        }

        [Authorize]
        public IActionResult All()
        {
            var allBatteries = this.batteryService.GetAllBatteries()
                .Select(x => new InfoBatteryModel()
                {
                    Id = x.Id,
                    Status = x.Status,
                    SoftwareVersion = x.SoftwareVersion,
                    Mileage = x.Mileage,
                    HorsePower = x.HorsePower,
                    KilowattHour = x.KilowattHour,
                    Range = x.Range,
                }).ToList();
            return this.View(allBatteries);
        }

        [Authorize]
        public IActionResult CountBatteries()
        {
            var count = this.batteryService.CountBatteries();
            return this.View(count);
        }
    }
}
