namespace TeslaService.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using TeslaService.Data.Models;
    using TeslaService.Services.Data.Dto;
    using TeslaService.Web.ViewModels.Battery;

    public interface IBatteryService
    {
        Task CreateBatteryAsync(InfoBatteryModel batteryDto);

        Task DeleteBattery(string batteryId);

        bool IsItBatteryCreated(string batteryId);

        IEnumerable<Battery> GetAllBatteries();

        int CountBatteries();
    }
}
