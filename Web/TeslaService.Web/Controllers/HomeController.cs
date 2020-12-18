namespace TeslaService.Web.Controllers
{
    using System.Diagnostics;
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;
    using TeslaService.Data;
    using TeslaService.Services.Data;
    using TeslaService.Web.ViewModels;
    using TeslaService.Web.ViewModels.Home;

    public class HomeController : BaseController
    {
        private readonly HomeService homeService;

        public HomeController(HomeService homeService)
        {
            this.homeService = homeService;
        }

        public IActionResult Index()
        {
            var usersCount = this.homeService.CountUsers();
            var vehiclesCount = this.homeService.CountVehicles();
            var partsCount = this.homeService.CountParts();
            var countpartsTypes = this.homeService.CountTypesOfParts();
            var employeesCount = this.homeService.CountEmployees();
            var batteryCount = this.homeService.CountBatteries();

            var info = new IndexViewModel()
            {
                UsersCount = usersCount,
                VehiclesCount = vehiclesCount,
                PartsCount = partsCount,
                CountTypesOfParts = countpartsTypes,
                EmployeesCount = employeesCount,
                BatteriesCount = batteryCount,
            };

            return this.View(info);
        }

        public IActionResult About()
        {
            return this.View();
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
