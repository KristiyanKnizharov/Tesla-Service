namespace TeslaService.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Microsoft.EntityFrameworkCore;
    using TeslaService.Data;
    using TeslaService.Data.Common.Repositories;
    using TeslaService.Data.Models;
    using TeslaService.Data.Models.Enum;
    using TeslaService.Data.Repositories;
    using TeslaService.Services.Data.Common;
    using TeslaService.Web.ViewModels.Vehicle;

    public class VehicleServiceTests
    {
        private readonly IVehicleService vehicleService;
        private IRepository<Vehicle> vehicleRepository;
        private IDeletableEntityRepository<ApplicationUser> userRepository;
        private IRepository<Insurance> insuranceRepository;
        private IRepository<Battery> batteryRepository;
        private IRepository<Service> serviceRepository;
        private IRepository<Part> partRepository;

        private ApplicationDbContext connection;

        public VehicleServiceTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb").Options;
            this.connection = new ApplicationDbContext(options);
            this.vehicleRepository = new EfRepository<Vehicle>(this.connection);
            this.userRepository = new EfDeletableEntityRepository<ApplicationUser>(this.connection);
            this.batteryRepository = new EfRepository<Battery>(this.connection);
            this.insuranceRepository = new EfRepository<Insurance>(this.connection);
            this.serviceRepository = new EfRepository<Service>(this.connection);
            this.partRepository = new EfRepository<Part>(this.connection);
            this.vehicleService = new VehicleService(vehicleRepository, userRepository,
                insuranceRepository, serviceRepository, partRepository, batteryRepository);
        }

        public void Dispose()
        {
            this.connection.Database.EnsureDeleted();
            this.connection.Dispose();
        }

        public void CreateNewVehicle()
        {
            var currUser = new ApplicationUser() { };
            var newBattery = new Battery()
            {
                Status = BatteryStatus.Good,
                SoftwareVersion = "2020.48.5",
                Mileage = 30000,
                HorsePower = 503,
                KilowattHour = 375,
                Range = 450,
            };
            var newVehicle = new CreateVehicleModel()
            {
                VehicleModel = VehicleModel.Model_3,
                VehicleType = VehicleType.Sedan,
                ImageURL = "https://stimg.cardekho.com/images/carexteriorimages/930x620/Tesla/Tesla-Model-3/5100/1558500541732/front-left-side-47.jpg?tr=h-48",
                DateOfPurchase = new DateTime(2018, 3, 15),
                Description = "My Tesla Model 3 car",
                ServiceId = 1,
                BatteryId = newBattery.Id,
            };
            this.vehicleService.CreateVehicle(currUser.Id, newVehicle);
            var expect = 1;
        }


    }
}
