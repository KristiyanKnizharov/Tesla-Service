namespace TeslaService.Services.Data
{
    using System;
    using System.Linq;

    using TeslaService.Data.Common.Repositories;
    using TeslaService.Data.Models;
    using TeslaService.Services.Data.Contracts;

    public class WarehouseService : IWarehouseService
    {
        private readonly IRepository<Warehouse> warehouseRepository;

        public WarehouseService(IRepository<Warehouse> warehouseRepository)
        {
            this.warehouseRepository = warehouseRepository;
        }

        public void CreateWarehouseAsync(int id)
        {
            var warehouse = new Warehouse()
            {
                Id = id,
            };
            this.warehouseRepository.AddAsync(warehouse);
            this.warehouseRepository.SaveChangesAsync();
        }

        public void DeleteWarehouseAsync(int id)
        {
            var warehouse = this.warehouseRepository.All()
                .FirstOrDefault(x => x.Id == id);
            if (warehouse == null)
            {
                throw new NullReferenceException("Warehouse not found");
            }

            this.warehouseRepository.Delete(warehouse);
            this.warehouseRepository.SaveChangesAsync();
        }

        public bool IsItWarehouseCreated(int id)
        {
            var warehouse = this.warehouseRepository.All()
                            .FirstOrDefault(x => x.Id == id);
            if (warehouse == null)
            {
                return false;
            }

            return true;
        }
    }
}
