namespace TeslaService.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using TeslaService.Services.Data.Contracts;

    public class ServiceController : Controller
    {
        private readonly IServiceService serviceService;

        public ServiceController(IServiceService serviceService)
        {
            this.serviceService = serviceService;
        }

        [Authorize]
        public IActionResult Info()
        {
            return this.View();
        }
    }
}
