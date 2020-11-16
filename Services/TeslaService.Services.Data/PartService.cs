namespace TeslaService.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using TeslaService.Data.Common.Repositories;
    using TeslaService.Data.Models;
    using TeslaService.Services.Data.Common;
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
            var part = this.partRepository.All().Where(x => x.Name == partName);
            part.Select(x => x.Quantity + 1);
            this.partRepository.Update(part as Part);
            await this.partRepository.SaveChangesAsync();
        }

        public int CountParts(string name)
        {
            return this.partRepository.All().Where(x => x.Name == name).Select(x => x.Quantity).Count();
        }

        public async void CreatePartAsync(string partName, double price)
        {
            if (string.IsNullOrWhiteSpace(partName) || partName.Length < 2)
            {
                throw new ArgumentException("Part name not valid.(Must be at least 2 symbols)");
            }
            else if (price < 0 || price > 100000)
            {
                throw new ArgumentException("Price must be between 0 and 100000.");
            }

            var part = new Part()
            {
                Name = partName,
                Price = price,
                Quantity = 1,
            };

            await this.partRepository.AddAsync(part);
            await this.partRepository.SaveChangesAsync();
        }

        public async void DelatePartAsync(string partName)
        {
            var exist = this.partRepository.All().Any(x => x.Name == partName);
            if (string.IsNullOrWhiteSpace(partName) || exist)
            {
                throw new ArgumentException("Cannot delete non-existent part.");
            }

            var part = this.partRepository.All()
                .FirstOrDefault(x => x.Name == partName);
            this.partRepository.Delete(part);
            await this.partRepository.SaveChangesAsync();
        }

        public ICollection<PartModel> GetAllParts()
        {
            var partsRepo = this.partRepository.All();
            return partsRepo as ICollection<PartModel>;
        }

        public bool IsItPartCreate(string partName)
        {
            return this.partRepository.All().Any(x => x.Name == partName);
        }

        public async void RemovePartAsync(string partName)
        {
            var part = this.partRepository.All().Where(x => x.Name == partName);
            part.Select(x => x.Quantity - 1);
            this.partRepository.Update(part as Part);
            await this.partRepository.SaveChangesAsync();
        }
    }
}
