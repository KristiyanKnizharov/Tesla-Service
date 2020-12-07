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

        public HomeService(
            IDeletableEntityRepository<ApplicationUser> userRepository,
            IRepository<Vehicle> vehicleRepository,
            IRepository<Part> partRepository)
        {
            this.userRepository = userRepository;
            this.vehicleRepository = vehicleRepository;
            this.partRepository = partRepository;
        }

        public int CountParts()
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
    }
}
