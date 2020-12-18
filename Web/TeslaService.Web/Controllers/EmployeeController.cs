namespace TeslaService.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using TeslaService.Services.Data.Contracts;
    using TeslaService.Web.ViewModels.Employee;

    public class EmployeeController : BaseController
    {
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public IActionResult All()
        {
            var allEmployees = this.employeeService.GetAllEmployees();
            return this.View(allEmployees);
        }

        [Authorize]
        public IActionResult Hire()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Hire(EmployeeModel employeeModel)
        {
            if (this.employeeService.IsTheEmpoyeeExist(employeeModel.FirstName + " " + employeeModel.LastName))
            {
                this.ModelState.AddModelError("Employee", "Employee with that name exist!");
            }

            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            await this.employeeService.HiredEmployeeAsync(employeeModel);
            return this.Redirect("/Employee/All");
        }
    }
}
