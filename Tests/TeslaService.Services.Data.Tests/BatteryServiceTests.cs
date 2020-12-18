namespace TeslaService.Services.Data.Tests
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using TeslaService.Data;
    using TeslaService.Data.Common.Repositories;
    using TeslaService.Data.Models;
    using TeslaService.Data.Models.Enum;
    using TeslaService.Data.Repositories;
    using TeslaService.Services.Data.Contracts;
    using TeslaService.Web.ViewModels.Battery;
    using Xunit;

    public class BatteryServiceTests
    {
        private readonly IBatteryService batteryService;
        private IRepository<Battery> batteryRepository;

        private ApplicationDbContext connection;

        public BatteryServiceTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb").Options;
            this.connection = new ApplicationDbContext(options);
            this.batteryRepository = new EfRepository<Battery>(this.connection);
            this.batteryService = new BatteryService(this.batteryRepository);
        }

        [Fact]
        public void Dispose()
        {
            this.connection.Database.EnsureDeleted();
            this.connection.Dispose();
        }

        [Fact]
        public async Task CreateBatteryAsync()
        {
            var newBattery = new InfoBatteryModel()
            {
                Id = "aa11bb22cc33",
                Status = BatteryStatus.Good,
                SoftwareVersion = "2020.48.5",
                Mileage = 30000,
                HorsePower = 503,
                KilowattHour = 375,
                Range = 450,
            };

            await this.batteryService.CreateBatteryAsync(newBattery);
            var battery = this.batteryRepository.All().FirstOrDefaultAsync();

            Assert.NotNull(battery);
        }

        //[Fact]
        //public async Task DeleteBatteryAsync()
        //{
        //    var newBattery = new InfoBatteryModel()
        //    {
        //        Id = "11bb22cc33dd",
        //        Status = BatteryStatus.Good,
        //        SoftwareVersion = "2020.48.5",
        //        Mileage = 30000,
        //        HorsePower = 503,
        //        KilowattHour = 375,
        //        Range = 450,
        //    };

        //    await this.batteryService.CreateBatteryAsync(newBattery);

        //    await this.batteryService.DeleteBattery(newBattery.Id);

        //    var expectResult = 0;
        //    var realResult = await this.batteryRepository.All().FirstOrDefaultAsync();

        //    Assert.Equal(expectResult,expectResult);
        //}

        [Fact]
        public async Task IsItBatteryCreatedTestAsync()
        {
            var newBattery = new InfoBatteryModel()
            {
                Id = "aa11bb22cc33",
                Status = BatteryStatus.Good,
                SoftwareVersion = "2020.48.5",
                Mileage = 30000,
                HorsePower = 503,
                KilowattHour = 375,
                Range = 450,
            };

            await this.batteryService.CreateBatteryAsync(newBattery);

            var expectResult = this.batteryService.GetAllBatteries().Any(x => x.Id == newBattery.Id);

            Assert.False(expectResult);
        }

        [Fact]
        public void GetAllBatteries()
        {
            var newBattery = new InfoBatteryModel()
            {
                Id = "aa11bb22cc33",
                Status = BatteryStatus.Good,
                SoftwareVersion = "2020.48.5",
                Mileage = 30000,
                HorsePower = 503,
                KilowattHour = 375,
                Range = 450,
            };

            this.batteryService.CreateBatteryAsync(newBattery);
            var allBatteriesCount = this.batteryService.GetAllBatteries().Count();
            var expect = 1;

            Assert.Equal(expect, allBatteriesCount);
        }

        [Fact]
        public void CountBatteries()
        {
            var newBattery = new InfoBatteryModel()
            {
                Id = "aa11bb22cc33",
                Status = BatteryStatus.Good,
                SoftwareVersion = "2020.48.5",
                Mileage = 30000,
                HorsePower = 503,
                KilowattHour = 375,
                Range = 450,
            };

            this.batteryService.CreateBatteryAsync(newBattery);
            var expected = 1;
            var allBatteriesCount = this.batteryService.CountBatteries();

            Assert.Equal(expected, allBatteriesCount);
        }

    }
}
