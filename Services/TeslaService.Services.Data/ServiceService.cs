namespace TeslaService.Services.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using TeslaService.Data.Common.Repositories;
    using TeslaService.Data.Models;
    using TeslaService.Services.Data.Contracts;
    using TeslaService.Web.ViewModels.Service;

    public class ServiceService : IServiceService
    {
        private const int ServiceId = 1;
        private const int WarehouseId = 1;
        private readonly IRepository<Service> serviceRepository;

        public ServiceService(IRepository<Service> serviceRepository)
        {
            this.serviceRepository = serviceRepository;
        }

        public async Task CreateServiceAsync(int id)
        {
            var newService = new Service()
            {
                Id = ServiceId,
                WarehouseId = WarehouseId,
            };
            await this.serviceRepository.AddAsync(newService);
            await this.serviceRepository.SaveChangesAsync();
        }

        public async Task DeleteServiceAsync(int id)
        {
            var service = this.serviceRepository.AllAsNoTracking()
                .FirstOrDefault(x => x.Id == id);
            if (service == null)
            {
                throw new NullReferenceException("Service not found");
            }

            this.serviceRepository.Delete(service);
            await this.serviceRepository.SaveChangesAsync();
        }

        public GetServiceModel GetServiceInfo(int id)
        {
            var repo = this.serviceRepository.All().FirstOrDefault(x => x.Id == id);
            var info = new GetServiceModel()
            {
                Id = repo.Id,
                WarehouseId = repo.WarehouseId,
                Vehicles = (System.Collections.Generic.IEnumerable<Web.ViewModels.Vehicle.InfoVehicleModel>)repo.Vehicles,
                Employees = (System.Collections.Generic.IEnumerable<Web.ViewModels.Employee.EmployeeModel>)repo.Employees,
            };

            return info;
        }

        public bool IsItServiceCreated(int id)
        {
            var service = this.serviceRepository.AllAsNoTracking()
                .FirstOrDefault(x => x.Id == id);
            if (service == null)
            {
                return false;
            }

            return true;
        }
    }
}
