namespace TeslaService.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using TeslaService.Services.Data.Contracts;
    using TeslaService.Web.ViewModels.Insurance;

    public class InsuranceController : BaseController
    {
        private readonly IInsuranceService insuranceService;

        public InsuranceController(IInsuranceService insuranceService)
        {
            this.insuranceService = insuranceService;
        }

        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(InfoInsuranceModel iim)
        {
            if (!this.insuranceService.IsItInsuranceCreated(iim.Id))
            {
                this.insuranceService.CreateInsuranceAsync(iim);
            }

            return this.Redirect("/Insurance/All");
        }

        [Authorize]
        public IActionResult All()
        {
            var allInsurances = this.insuranceService.GetAllInsurances();
            return this.View(allInsurances);
        }
    }
}
