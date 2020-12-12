namespace TeslaService.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using TeslaService.Data.Common.Repositories;
    using TeslaService.Data.Models;
    using TeslaService.Services.Data.Common;
    using TeslaService.Services.Data.Dto;
    using TeslaService.Web.ViewModels.Parts;
    using TeslaService.Web.ViewModels.Vehicle;

    public class VehicleService : IVehicleService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> userRepository;
        private readonly IRepository<Vehicle> vehicleRepository;
        private readonly IRepository<Insurance> insuranceRepository;
        private readonly IRepository<Part> partRepository;

        public VehicleService(
            IRepository<Vehicle> vehicle,
            IDeletableEntityRepository<ApplicationUser> user,
            IRepository<Insurance> insuranceRepository,
            IRepository<Part> partRepository)
        {
            this.userRepository = user;
            this.vehicleRepository = vehicle;
            this.insuranceRepository = insuranceRepository;
            this.partRepository = partRepository;
        }

        public void AddNewBattery(string vehicleId, BatteryDto dto)
        {
            var currVehicle = this.vehicleRepository.All()
                .Where(x => x.Id == vehicleId);

            var newBattery = new Battery()
            {
                Id = vehicleId,
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

        public Insurance CreateInsurance(string vehicleId)
        {
            var dateUtcNow = DateTime.UtcNow.Date.ToString("dd/MM/yyyy");
            var dateInsuranceEnd = DateTime.UtcNow.Date.AddYears(1).ToString("dd/MM/yyyy");
            var currVehicleVIN = this.vehicleRepository.All().Where(x => x.Id == vehicleId).Select(x => x.Id).ToString();
            var insurance = new Insurance()
            {
                VinNumber = currVehicleVIN,
                DateOfStart = dateUtcNow,
                DateOfEnd = dateInsuranceEnd,
                Description = $"Insurance is valid from {dateUtcNow} to {dateInsuranceEnd}.The Tesla company is always there when you need help. Contact: EUPress@tesla.com",
            };
            this.insuranceRepository.AddAsync(insurance);

            return insurance;
        }

        public void CreateVehicle(string userId, CreateVehicleModel vehicle)
        {
            if (this.userRepository.All().Any(x => x.Id == userId))
            {
                var currVehicle = new Vehicle()
                {
                    VehicleModel = vehicle.VehicleModel,
                    VehicleType = vehicle.VehicleType,
                    ImageURL = vehicle.ImageURL,
                    DateOfPurchase = vehicle.DateOfPurchase,
                    BatteryId = vehicle.BatteryId,
                    UserId = userId,
                    Description = vehicle.Description,
                    InsuranceId = vehicle.InsuranceId,
                    ServiceId = vehicle.ServiceId,
                };
                this.vehicleRepository.AddAsync(currVehicle);
                this.vehicleRepository.SaveChangesAsync();
            }
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

            var allParts = currVehicle.Select(x => x.RepairedPart).ToList();

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

        public IEnumerable<Vehicle> GetAllVehicles(string userId)
        {
            var allVehicles = this.userRepository.All()
                .Where(u => u.Id == userId)
                .SelectMany(x => x.Vehicles.Select(c => new Vehicle()
                {
                    VehicleModel = c.VehicleModel,
                    VehicleType = c.VehicleType,
                    ImageURL = c.ImageURL,
                    DateOfPurchase = c.DateOfPurchase,
                    BatteryId = c.BatteryId,
                    Description = c.Description,
                    InsuranceId = c.InsuranceId,
                    ServiceId = c.ServiceId,
                })) as IEnumerable<Vehicle>;

            return allVehicles;
        }
    }
}
