namespace TeslaService.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using TeslaService.Data.Models;
    using TeslaService.Web.ViewModels.Insurance;

    public interface IInsuranceService
    {
        Task CreateInsuranceAsync(InfoInsuranceModel insuranceModel);

        void DeleteInsurance(string insuranceId);

        bool IsItInsuranceCreated(string insuranceId);

        IEnumerable<Insurance> GetAllInsurances();

        int CountInsurances();
    }
}
