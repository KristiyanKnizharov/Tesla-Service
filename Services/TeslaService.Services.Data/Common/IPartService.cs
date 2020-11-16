namespace TeslaService.Services.Data.Common
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using TeslaService.Web.ViewModels.Parts;

    public interface IPartService
    {
        void CreatePartAsync(string partName, double price);

        void DelatePartAsync(string partName);

        void AddPartAsync(string partName);

        void RemovePartAsync(string partName);

        bool IsItPartCreate(string partName);

        ICollection<PartModel> GetAllParts();

        int CountParts(string name);
    }
}
