namespace TeslaService.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using TeslaService.Data.Models;
    using TeslaService.Data.Models.Enum;

    public class CustomSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (!dbContext.Parts.Any())
            {
                //// Add part
                await dbContext.Parts.AddAsync(new Part()
                {
                    Name = "Bonnet",
                    Price = 400.00,
                    Quantity = 1,
                });
                await dbContext.SaveChangesAsync();
            }

            var part = dbContext.Parts.FirstOrDefault();

            //// Add battery
            if (!dbContext.Batteries.Any())
            {
                await dbContext.Batteries.AddAsync(new Battery()
                {
                    Status = BatteryStatus.Good,
                    SoftwareVersion = "2020.48.5",
                    Mileage = 30000,
                    HorsePower = 503,
                    KilowattHour = 375,
                    Range = 450,
                });
                await dbContext.SaveChangesAsync();
            }

            var battery = dbContext.Batteries.FirstOrDefault();

            //// Add Warehouse
            if (!dbContext.Warehouses.Any())
            {
                await dbContext.Warehouses.AddAsync(new Warehouse()
                {
                    Location = "Sofia",
                    Parts = new HashSet<Part>() { part },
                });

                await dbContext.SaveChangesAsync();
            }

            var warehouse = dbContext.Warehouses.FirstOrDefault();

            //// Add Service
            if (!dbContext.Services.Any())
            {
                var service = new Service() { Warehouse = warehouse };
                await dbContext.Services.AddAsync(service);
                await dbContext.SaveChangesAsync();
            }

            //// Add Employee
            if (!dbContext.Employees.Any())
            {
                await dbContext.Employees.AddAsync(new Employee()
                {
                    FirstName = "Peter",
                    LastName = "Stanoev",
                    ImageURL = "https://i2-prod.irishmirror.ie/incoming/article5425955.ece/ALTERNATES/s615b/MOST-BEAUTIFUL-FACES.jpg",
                    Position = "Account manager",
                    ServiceId = dbContext.Services.FirstOrDefault().Id,
                    DateOfJoin = DateTime.UtcNow.Date.ToString("dd/MM/yyyy"),
                });
                await dbContext.Employees.AddAsync(new Employee()
                {
                    FirstName = "Mike",
                    LastName = "Morino",
                    ImageURL = "https://ath2.unileverservices.com/wp-content/uploads/sites/8/2019/09/hairstyles-for-men-with-round-faces-jagged-spikes-shutterstock.jpg",
                    Position = "CTO",
                    ServiceId = dbContext.Services.FirstOrDefault().Id,
                    DateOfJoin = DateTime.UtcNow.Date.ToString("dd/MM/yyyy"),
                });
                await dbContext.Employees.AddAsync(new Employee()
                {
                    FirstName = "Neil",
                    LastName = "Robertson",
                    ImageURL = "https://upload.wikimedia.org/wikipedia/en/6/69/NeilRobertson2016.png",
                    Position = "Mechanic",
                    ServiceId = dbContext.Services.FirstOrDefault().Id,
                    DateOfJoin = DateTime.UtcNow.Date.ToString("dd/MM/yyyy"),
                });

                await dbContext.SaveChangesAsync();
            }

            //// Add insurance
            if (!dbContext.Insurances.Any())
            {
                await dbContext.Insurances.AddAsync(new Insurance()
                {
                    VinNumber = "000001",
                    DateOfStart = DateTime.UtcNow.Date.ToString("dd/MM/yyyy"),
                    DateOfEnd = DateTime.UtcNow.Date.AddYears(1).ToString("dd/MM/yyyy"),
                    Description = "Insurance cost 100lv.",
                });
                await dbContext.SaveChangesAsync();
            }

            var insurance = dbContext.Insurances.FirstOrDefault();

            //// Add vehicle
            ////await dbContext.Vehicles.AddAsync(new Vehicle()
            ////{
            ////    VehicleModel = VehicleModel.Model_3,
            ////    VehicleType = VehicleType.Sedan,
            ////    ImageURL = "https://stimg.cardekho.com/images/carexteriorimages/930x620/Tesla/Tesla-Model-3/5100/1558500541732/front-left-side-47.jpg?tr=h-48",
            ////    DateOfPurchase = new DateTime(2018, 3, 15),
            ////    BatteryId = battery.Id,
            ////    Description = "Used car",
            ////    UserId = this.userManager.GetUserAsync(this.User),
            ////    ServiceId = service.Id,
            ////    InsuranceId = insurance.Id
            ////});
        }
    }
}
