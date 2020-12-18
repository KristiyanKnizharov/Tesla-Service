namespace TeslaService.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using TeslaService.Data.Common.Repositories;
    using TeslaService.Data.Models;
    using TeslaService.Services.Data.Contracts;
    using TeslaService.Web.ViewModels.Battery;

    public class BatteryService : IBatteryService
    {
        private readonly IRepository<Battery> batteryRepository;

        public BatteryService(IRepository<Battery> batteryRepository)
        {
            this.batteryRepository = batteryRepository;
        }

        public int CountBatteries()
        {
            return this.batteryRepository.AllAsNoTracking().Count();
        }

        public async Task CreateBatteryAsync(InfoBatteryModel batteryDto)
        {
            var battery = new Battery()
            {
                Status = batteryDto.Status,
                SoftwareVersion = batteryDto.SoftwareVersion,
                Mileage = batteryDto.Mileage,
                HorsePower = batteryDto.HorsePower,
                KilowattHour = batteryDto.KilowattHour,
                Range = batteryDto.Range,
            };

            await this.batteryRepository.AddAsync(battery);
            await this.batteryRepository.SaveChangesAsync();
        }

        public async Task DeleteBattery(string batteryId)
        {
            var battery = this.batteryRepository.All()
                .FirstOrDefault(x => x.Id == batteryId);

            this.batteryRepository.Delete(battery);
            await this.batteryRepository.SaveChangesAsync();
        }

        public IEnumerable<Battery> GetAllBatteries()
        {
            var allBatteries = this.batteryRepository.All();
            return allBatteries;
        }

        public bool IsItBatteryCreated(string batteryId)
        {
            return this.batteryRepository.AllAsNoTracking()
                .Any(x => x.Id == batteryId);
        }
    }
}
