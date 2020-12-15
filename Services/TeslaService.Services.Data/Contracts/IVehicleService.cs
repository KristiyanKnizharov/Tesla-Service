namespace TeslaService.Services.Data.Common
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using TeslaService.Data.Models;
    using TeslaService.Services.Data.Dto;
    using TeslaService.Web.ViewModels.Parts;
    using TeslaService.Web.ViewModels.Vehicle;

    public interface IVehicleService
    {
        void CreateVehicle(string userId, CreateVehicleModel vehicle);

        void DeleteVehicle(string userId, string vehicleId);

        void AddNewBattery(string vehicleId, BatteryDto dto);

        Insurance CreateInsurance(string vehicleId);

        VehicleDto Details(string id, Task<ApplicationUser> user);

        bool IsItVehicleCreated(string vehicleId);

        bool IsItInsuranceCreated(string insuranceId);

        IEnumerable<DetailsVehicleModel> GetAllVehicles(string userId);

        IEnumerable<PartModel> GetAllRepairedParts(string vehicleId);
    }
}
