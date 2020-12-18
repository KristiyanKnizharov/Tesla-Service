namespace TeslaService.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using TeslaService.Data.Common.Repositories;
    using TeslaService.Data.Models;
    using TeslaService.Services.Data.Common;
    using TeslaService.Services.Data.Dto;
    using TeslaService.Web.ViewModels.Battery;
    using TeslaService.Web.ViewModels.Parts;
    using TeslaService.Web.ViewModels.Vehicle;

    public class VehicleService : IVehicleService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> userRepository;
        private readonly IRepository<Vehicle> vehicleRepository;
        private readonly IRepository<Service> serviceRepository;
        private readonly IRepository<Insurance> insuranceRepository;
        private readonly IRepository<Part> partRepository;
        private readonly IRepository<Battery> batteryRepository;

        public VehicleService(
            IRepository<Vehicle> vehicleRepository,
            IDeletableEntityRepository<ApplicationUser> userRepository,
            IRepository<Insurance> insuranceRepository,
            IRepository<Service> serviceRepository,
            IRepository<Part> partRepository,
            IRepository<Battery> batteryRepository)
        {
            this.userRepository = userRepository;
            this.vehicleRepository = vehicleRepository;
            this.serviceRepository = serviceRepository;
            this.insuranceRepository = insuranceRepository;
            this.partRepository = partRepository;
            this.batteryRepository = batteryRepository;
        }

        public void AddNewBattery(string vehicleId, BatteryDto dto)
        {
            var currVehicle = this.vehicleRepository.All()
                .Where(x => x.Id == vehicleId);

            var newBattery = new Battery()
            {
                Status = TeslaService.Data.Models.Enum.BatteryStatus.Excellent,
                SoftwareVersion = dto.SoftwareVersion,
                Mileage = dto.Mileage,
                HorsePower = dto.HorsePower,
                KilowattHour = dto.KilowattHour,
                Range = dto.Range,
            };
            currVehicle.Select(x => x.Battery == newBattery);
            this.vehicleRepository.SaveChangesAsync();
        }

        public void CreateVehicle(string userId, CreateVehicleModel vehicle)
        {
            if (this.userRepository.All().Any(x => x.Id == userId))
            {
                var currBattery = this.batteryRepository.All().FirstOrDefault(x => x.Id == vehicle.BatteryId.Trim());
                var currInsurance = this.insuranceRepository.All().FirstOrDefault(x => x.Id == vehicle.InsuranceId.Trim());
                var currService = this.serviceRepository.All().FirstOrDefault(x => x.Id == vehicle.ServiceId);

                if (currBattery == null || currInsurance == null || currService == null)
                {
                    return;
                }

                var currVehicle = new Vehicle()
                {
                    VehicleModel = vehicle.VehicleModel,
                    VehicleType = vehicle.VehicleType,
                    ImageURL = vehicle.ImageURL,
                    DateOfPurchase = vehicle.DateOfPurchase,
                    BatteryId = vehicle.BatteryId,
                    Battery = currBattery,
                    UserId = userId,
                    User = this.userRepository.All().FirstOrDefault(x => x.Id == userId),
                    Description = vehicle.Description,
                    InsuranceId = vehicle.InsuranceId,
                    Insurance = currInsurance,
                    ServiceId = vehicle.ServiceId,
                    Service = currService,
                };
                this.vehicleRepository.AddAsync(currVehicle).GetAwaiter().GetResult();
                this.vehicleRepository.SaveChangesAsync().GetAwaiter().GetResult();
            }
        }

        public VehicleDto Details(string id)
        {
            var vehicle = this.vehicleRepository.All().FirstOrDefault(x => x.Id == id);

            if (vehicle == null)
            {
                throw new ArgumentException("There is no info for this vehicle.");
            }

            var battery = this.batteryRepository.All().FirstOrDefault(x => x.Id == vehicle.BatteryId);

            var vehicleDto = new VehicleDto()
            {
                VehicleModel = vehicle.VehicleModel,
                VehicleType = vehicle.VehicleType,
                ImageURL = vehicle.ImageURL,
                DateOfPurchase = vehicle.DateOfPurchase,
                BatteryId = vehicle.BatteryId,
                Battery = battery,
                Description = vehicle.Description,
                UserId = vehicle.UserId,
                ServiceId = vehicle.ServiceId,
                InsuranceId = vehicle.InsuranceId,
            };
            return vehicleDto;
        }

        public void DeleteVehicle(string userId, string vehicleId)
        {
            var currVehicle = this.vehicleRepository.All()
                .Where(x => x.Id == vehicleId);
            this.vehicleRepository.Delete(currVehicle as Vehicle);
            this.vehicleRepository.SaveChangesAsync();
        }

        public IEnumerable<PartModel> GetAllRepairedParts(string vehicleId)
        {
            var currVehicle = this.vehicleRepository.All()
                .Where(x => x.Id == vehicleId);

            var allParts = currVehicle.Select(x => x.RepairedParts).ToList();

            return allParts as IEnumerable<PartModel>;
        }

        public bool IsItVehicleCreated(string vehicleId)
        {
            return this.vehicleRepository.All()
                .Any(x => x.Id == vehicleId);
        }

        public bool IsItUserCreated(string userId)
        {
            return this.userRepository.All()
                .Any(x => x.Id == userId);
        }

        public bool IsItInsuranceCreated(string insuranceId)
        {
            return this.insuranceRepository.All()
                .Any(x => x.Id == insuranceId);
        }

        public IEnumerable<DetailsVehicleModel> GetAllVehicles(string userId)
        {
            var user = this.userRepository.AllAsNoTracking()
                .FirstOrDefault(u => u.Id == userId);
            var vehicles = this.vehicleRepository.All().FirstOrDefault();
            var battery = this.batteryRepository.All().FirstOrDefault();

            var batteryInfo = this.batteryRepository.All().Where(i => i.Id == battery.Id)
                .Select(b => new InfoBatteryModel()
            {
                HorsePower = b.HorsePower,
                KilowattHour = b.KilowattHour,
                Mileage = b.Mileage,
                Range = b.Range,
                SoftwareVersion = b.SoftwareVersion,
                Status = b.Status,
            });
            var allVehicles = this.vehicleRepository.All().Where(x => x.UserId == user.Id)
                .Select(c => new DetailsVehicleModel()
                {
                    Id = c.Id,
                    VehicleModel = c.VehicleModel,
                    VehicleType = c.VehicleType,
                    ImageURL = c.ImageURL,
                    DateOfPurchase = c.DateOfPurchase,
                    BatteryId = c.BatteryId,
                    Battery = batteryInfo as InfoBatteryModel,
                    Description = c.Description,
                    InsuranceId = c.InsuranceId,
                    ServiceId = c.ServiceId,
                }).ToList();

            return allVehicles;
        }
    }
}
