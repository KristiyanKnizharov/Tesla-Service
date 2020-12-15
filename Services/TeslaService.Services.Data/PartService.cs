namespace TeslaService.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using TeslaService.Data.Common.Repositories;
    using TeslaService.Data.Models;
    using TeslaService.Data.Models.Enum;
    using TeslaService.Services.Data.Common;
    using TeslaService.Services.Data.Dto;
    using TeslaService.Web.ViewModels.Part;
    using TeslaService.Web.ViewModels.Parts;

    public class PartService : IPartService
    {
        private readonly IRepository<Part> partRepository;

        public PartService(IRepository<Part> partRepository)
        {
            this.partRepository = partRepository;
        }

        public async void AddPartAsync(string partName)
        {
            if (this.partRepository.AllAsNoTracking().Any(x => x.Name == partName))
            {
                this.partRepository.All().Where(x => x.Name == partName).Select(x => x.Quantity + 1);
                await this.partRepository.SaveChangesAsync();
            }
        }

        public int CountParts(string name)
        {
            return this.partRepository.All().Where(x => x.Name == name).Select(x => x.Quantity).Count();
        }

        public async Task CreatePartAsync(CreatePartModel cpm)
        {
            if (string.IsNullOrWhiteSpace(cpm.Name) || cpm.Name.Length < 2)
            {
                throw new ArgumentException("Part name not valid.(Must be at least 2 symbols)");
            }
            else if (cpm.Price < 0 || cpm.Price > 100000)
            {
                throw new ArgumentException("Price must be between 0 and 100000.");
            }
            else if (cpm.Quantity <= 0 || cpm.Quantity > 100)
            {
                throw new ArgumentException("Quantity not valid.");
            }

            var part = new Part()
            {
                Name = cpm.Name,
                Price = cpm.Price,
                Quantity = cpm.Quantity,
                VehicleModel = cpm.VehicleModel,
            };

            await this.partRepository.AddAsync(part);
            await this.partRepository.SaveChangesAsync();
        }

        public async void DeletePartAsync(string partName)
        {
            var exist = this.partRepository.AllAsNoTracking().Any(x => x.Name == partName);
            if (string.IsNullOrWhiteSpace(partName) || !exist)
            {
                throw new ArgumentException("Cannot delete non-existent part.");
            }

            var part = this.partRepository.All()
                .FirstOrDefault(x => x.Name == partName);
            this.partRepository.Delete(part);
            await this.partRepository.SaveChangesAsync();
        }

        public IEnumerable<PartModel> GetAllParts()
        {
            var parts = this.partRepository.All()
                .Select(x => new PartModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    Quantity = x.Quantity,
                    VehicleModel = x.VehicleModel,
                })
                .ToList()
                .OrderBy(x => x.Name);

            return parts;
        }

        public bool IsItPartCreated(string partName)
        {
            return this.partRepository.All().Any(x => (x.Name == partName));
        }

        public bool IsItPartWithModelCreated(string partName, VehicleModel model)
        {
            return this.partRepository.All().Any(x => ((x.Name == partName) && (x.VehicleModel == model)));
        }

        public async void RemovePartAsync(string partName)
        {
            if (int.Parse(this.partRepository.AllAsNoTracking()
                .Where(x => x.Name == partName).Select(x => x.Quantity).ToString()) <= 1)
            {
                this.DeletePartAsync(partName);
                return;
            }

            var part = this.partRepository.AllAsNoTracking()
                .Where(x => x.Name == partName).Select(x => new Part()
                {
                    Name = x.Name,
                    Price = x.Price,
                    Quantity = x.Quantity - 1,
                    VehicleModel = x.VehicleModel,
                }) as Part;
            this.partRepository.Update(part);
            await this.partRepository.SaveChangesAsync();
        }
    }
}
