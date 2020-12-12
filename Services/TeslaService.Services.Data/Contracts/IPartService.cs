namespace TeslaService.Services.Data.Common
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using TeslaService.Web.ViewModels.Parts;

    public interface IPartService
    {
        Task CreatePartAsync(string partName, double price);

        void DeletePartAsync(string partName);

        void AddPartAsync(string partName);

        void RemovePartAsync(string partName);

        bool IsItPartCreated(string partName);

        IEnumerable<PartModel> GetAllParts();

        int CountParts(string name);
    }
}
