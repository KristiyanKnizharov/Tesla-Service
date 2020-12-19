namespace TeslaService.Services.Data.Tests
{
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using TeslaService.Data;
    using TeslaService.Data.Common.Repositories;
    using TeslaService.Data.Models;
    using TeslaService.Data.Models.Enum;
    using TeslaService.Data.Repositories;
    using TeslaService.Services.Data.Common;
    using TeslaService.Web.ViewModels.Part;
    using Xunit;

    public class PartServiceTests
    {
        private readonly IPartService partService;
        private IRepository<Part> partRepository;

        private ApplicationDbContext connection;

        public PartServiceTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                            .UseInMemoryDatabase(databaseName: "TestDb").Options;
            this.connection = new ApplicationDbContext(options);
            this.partRepository = new EfRepository<Part>(this.connection);
            this.partService = new PartService(this.partRepository);
        }

        [Fact]
        public async Task CreatePartAsyncTest()
        {
            var part = new CreatePartModel()
            {
                Name = "Bonnet",
                Price = 400.00,
                Quantity = 1,
                VehicleModel = VehicleModel.Model_3,
            };

            await this.partService.CreatePartAsync(part);
            var expect = this.partRepository.All().CountAsync().GetAwaiter().GetResult();
            var result = this.partService.CountParts(part.Name);
            Assert.Equal(expect, result);
        }
    }
}
