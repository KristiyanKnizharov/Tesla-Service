namespace TeslaService.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using TeslaService.Data.Common.Repositories;
    using TeslaService.Data.Models;
    using TeslaService.Services.Data.Contracts;
    using TeslaService.Web.ViewModels.Employee;

    public class EmployeeService : IEmployeeService
    {
        private const int ServiceNumber = 1;

        private readonly IRepository<Employee> employeeRepository;

        public EmployeeService(IRepository<Employee> employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public int CountEmployee()
        {
            return this.employeeRepository.AllAsNoTracking().Count();
        }

        public async Task FiredEmployeeAsync(int employeeId)
        {
            var currentEmployee = this.employeeRepository.All().FirstOrDefault(x => x.Id == employeeId);
            if (currentEmployee != null)
            {
                this.employeeRepository.Delete(currentEmployee);
                await this.employeeRepository.SaveChangesAsync();
            }
        }

        public IEnumerable<EmployeeModel> GetAllEmployee()
        {
            var allEmployee = this.employeeRepository.AllAsNoTracking()
                .ToList()
                .Select(x => new EmployeeModel()
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    ImageURL = x.ImageURL,
                    Position = x.Position,
                    ServiceId = x.ServiceId,
                });

            return allEmployee;
        }

        public async Task HiredEmployeeAsync(EmployeeModel employee)
        {
            var newEmployee = new Employee()
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Position = employee.Position,
                ImageURL = employee.ImageURL,
                ServiceId = ServiceNumber,
            };
            await this.employeeRepository.AddAsync(newEmployee);
            await this.employeeRepository.SaveChangesAsync();
        }

        public bool IsTheEmpoyeeExist(string fullName)
        {
            return this.employeeRepository.AllAsNoTracking().Any(x => x.FirstName + " " + x.LastName == fullName);
        }
    }
}
