namespace TeslaService.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using TeslaService.Data.Models;

    public class PartsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Parts.Any())
            {
                return;
            }

            await dbContext.Parts.AddAsync(new Part() { Name = "Bonnet", Price = 400.00, Quantity = 1 });
            await dbContext.SaveChangesAsync();
            var part = dbContext.Parts.FirstOrDefault();
            await dbContext.Warehouses.AddAsync(new Warehouse() { Parts = new HashSet<Part>() { part } });
            var warehouse = dbContext.Warehouses.FirstOrDefault();
            await dbContext.Services.AddAsync(new Service() { Warehouse = warehouse });
            var service = dbContext.Services.FirstOrDefault();
            await dbContext.Vehicles.AddAsync(new Vehicle() { Service = service });
            await dbContext.SaveChangesAsync();

            ////dbContext.Warehouses.Add(new Warehouse { Parts = new {part},  })
        }
    }
}
