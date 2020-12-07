namespace TeslaService.Services.Data.Contracts
{
    using System.Threading.Tasks;

    using TeslaService.Web.ViewModels.Service;

    public interface IServiceService
    {
        Task CreateServiceAsync(int id);

        Task DeleteServiceAsync(int id);

        bool IsItServiceCreated(int id);

        GetServiceModel GetServiceInfo(int id);
    }
}
