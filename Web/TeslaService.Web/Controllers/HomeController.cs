namespace TeslaService.Web.Controllers
{
    using System.Diagnostics;
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;
    using TeslaService.Data;
    using TeslaService.Web.ViewModels;
    using TeslaService.Web.ViewModels.Home;

    public class HomeController : BaseController
    {
        private readonly ApplicationDbContext db;

        public HomeController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            var userRegisterCount = this.db.Users.Count();
            var vehicleRegisterCount = this.db.Vehicles.Count();
            var countParts = this.db.Parts.Count();

            var info = new IndexViewModel()
            {
                UserRegisterCount = userRegisterCount,
                VehicleRegisterCount = vehicleRegisterCount,
                CountParts = countParts,
            };

            return this.View(info);
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
