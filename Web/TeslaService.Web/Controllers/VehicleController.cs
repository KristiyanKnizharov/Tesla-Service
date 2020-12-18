namespace TeslaService.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using TeslaService.Data.Models;
    using TeslaService.Data.Models.Enum;
    using TeslaService.Services.Data.Common;
    using TeslaService.Web.ViewModels.Vehicle;

    public class VehicleController : BaseController
    {
        private readonly IVehicleService vehicleService;
        private readonly UserManager<ApplicationUser> userManager;

        public VehicleController(
            IVehicleService vehicleService,
            UserManager<ApplicationUser> userManager)
        {
            this.vehicleService = vehicleService;
            this.userManager = userManager;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var user = await this.userManager.GetUserAsync(this.User);
            var allVehicles = this.vehicleService.GetAllVehicles(user.Id);

            return this.View(allVehicles);
        }

        [Authorize]
        public IActionResult Create()
        {
            var viewModel = new CreateVehicleModel();
            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateVehicleModel input)
        {
            var user = await this.userManager.GetUserAsync(this.User);
            if (!Enum.IsDefined(typeof(VehicleType), input.VehicleType))
            {
                return this.NotFound("Vehicle type not exist!");
            }
            else if (!Enum.IsDefined(typeof(VehicleModel), input.VehicleModel))
            {
                return this.NotFound("Vehicle model not exist!");
            }

            var validDate = DateTime.Compare(input.DateOfPurchase, DateTime.UtcNow);

            if (validDate > 0)
            {
                return this.ValidationProblem("You set date from future!");
            }
            try
            {
                WebRequest webRequest = WebRequest.Create(input.ImageURL);
                WebResponse webResponse = await webRequest.GetResponseAsync();
            }
            catch //// If exception thrown then couldn't get response from address
            {
                return this.NotFound();
            }

            this.vehicleService.CreateVehicle(user.Id, input);
            return this.Redirect("All");
        }

        [Authorize]
        public IActionResult Details(string id)
        {
            var vehicleDto = this.vehicleService.Details(id);
            return this.View(vehicleDto);
        }

        public IActionResult All()
        {
            var userId = this.userManager.GetUserId(this.User);

            var vehicles = this.vehicleService.GetAllVehicles(userId);
            return this.View(vehicles);
        }
    }
}
