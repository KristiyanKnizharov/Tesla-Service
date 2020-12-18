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
    using TeslaService.Data.Repositories;
    using TeslaService.Services.Data.Contracts;
    using TeslaService.Web.ViewModels.Insurance;
    using Xunit;
    public class InsuranceServiceTests
    {
        private readonly IInsuranceService insuranceService;
        private IRepository<Insurance> insuranceRepository;

        private ApplicationDbContext connection;

        public InsuranceServiceTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb").Options;
            this.connection = new ApplicationDbContext(options);
            this.insuranceRepository = new EfRepository<Insurance>(this.connection);
            this.insuranceService = new InsuranceService(this.insuranceRepository);
        }

        public void Dispose()
        {
            this.connection.Database.EnsureDeleted();
            this.connection.Dispose();
        }

        [Fact]
        public void CountInsurances()
        {
            var insurance = new InfoInsuranceModel()
            {
                Id = "aa11bb22cc33",
                VinNumber = "000001",
                DateOfStart = DateTime.UtcNow.Date,
                DateOfEnd = DateTime.UtcNow.Date.AddYears(1),
                Description = "Insurance cost 100lv.",
            };

            this.insuranceService.CreateInsuranceAsync(insurance);
            var expect = 1;
            var real = this.insuranceService.CountInsurances();

            Assert.Equal(expect, real);
        }

        [Fact]
        public void AllInsurances()
        {
            var insurance = new InfoInsuranceModel()
            {
                Id = "aa11bb22cc33",
                VinNumber = "000001",
                DateOfStart = DateTime.UtcNow.Date,
                DateOfEnd = DateTime.UtcNow.Date.AddYears(1),
                Description = "Insurance cost 100lv.",
            };

            this.insuranceService.CreateInsuranceAsync(insurance);
            var expect = 1;
            var real = this.insuranceService.GetAllInsurances().Count();

            Assert.Equal(expect, real);
        }

        [Fact]
        public void CreateInsurances()
        {
            var insurance = new InfoInsuranceModel()
            {
                Id = "aa11bb22cc33",
                VinNumber = "000001",
                DateOfStart = DateTime.UtcNow.Date,
                DateOfEnd = DateTime.UtcNow.Date.AddYears(1),
                Description = "Insurance cost 100lv.",
            };

            this.insuranceService.CreateInsuranceAsync(insurance);
            var expect = 1;
            var real = this.insuranceService.GetAllInsurances().Count();

            Assert.Equal(expect, real);
        }

        [Fact]
        public void IsItInsuranceCreatedAsync()
        {
            var insurance = new Insurance()
            {
                Id = "aa11bb22cc33",
                VinNumber = "000001",
                DateOfStart = DateTime.UtcNow.Date.ToString("D"),
                DateOfEnd = DateTime.UtcNow.Date.AddYears(1).ToString("D"),
                Description = "Insurance cost 100lv.",
            };

            this.insuranceRepository.AddAsync(insurance);
            //var real = this.insuranceService.IsItInsuranceCreated(insurance.Id);
            var real = this.insuranceRepository.AllAsNoTracking().Any(x => x.Id == insurance.Id);
            Assert.False(real);
        }
    }
}
