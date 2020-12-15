namespace TeslaService.Services.Data.Common
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TeslaService.Data.Models.Enum;
    using TeslaService.Web.ViewModels.Part;
    using TeslaService.Web.ViewModels.Parts;

    public interface IPartService
    {
        Task CreatePartAsync(CreatePartModel cpm);

        void DeletePartAsync(string partName);

        void AddPartAsync(string partName);

        void RemovePartAsync(string partName);

        bool IsItPartCreated(string partName);

        bool IsItPartWithModelCreated(string partName, VehicleModel model);

        IEnumerable<PartModel> GetAllParts();

        int CountParts(string name);
    }
}
