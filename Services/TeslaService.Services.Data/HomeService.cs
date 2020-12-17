namespace TeslaService.Services.Data
{
    using System.Linq;

    using TeslaService.Data.Common.Repositories;
    using TeslaService.Data.Models;
    using TeslaService.Services.Data.Common;

    public class HomeService : IHomeService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> userRepository;
        private readonly IRepository<Vehicle> vehicleRepository;
        private readonly IRepository<Part> partRepository;
        private readonly IRepository<Employee> employeeRepository;

        public HomeService(
            IDeletableEntityRepository<ApplicationUser> userRepository,
            IRepository<Vehicle> vehicleRepository,
            IRepository<Part> partRepository,
            IRepository<Employee> employeeRepository)
        {
            this.userRepository = userRepository;
            this.vehicleRepository = vehicleRepository;
            this.partRepository = partRepository;
            this.employeeRepository = employeeRepository;
        }

        public int CountParts()
        {
            return this.partRepository.All().Sum(x => x.Quantity);
        }

        public int CountTypesOfParts()
        {
            return this.partRepository.All().Count();
        }

        public int CountUsers()
        {
            return this.userRepository.All().Count();
        }

        public int CountVehicles()
        {
            return this.vehicleRepository.All().Count();
        }

        public int CountEmployees()
        {
            return this.employeeRepository.All().Count();
        }
    }
}
