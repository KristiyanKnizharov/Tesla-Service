namespace TeslaService.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TeslaService.Data.Common.Repositories;
    using TeslaService.Data.Models;
    using TeslaService.Services.Data.Contracts;
    using TeslaService.Web.ViewModels.Insurance;

    public class InsuranceService : IInsuranceService
    {
        private readonly IRepository<Insurance> insuranceRepository;

        public InsuranceService(IRepository<Insurance> insuranceRepository)
        {
            this.insuranceRepository = insuranceRepository;
        }

        public int CountInsurances()
        {
            return this.insuranceRepository.AllAsNoTracking().Count();
        }

        public Task CreateInsuranceAsync(InfoInsuranceModel insuranceModel)
        {
            throw new NotImplementedException();
        }

        public void DeleteInsurance(string insuranceId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Insurance> GetAllInsurances()
        {
            throw new NotImplementedException();
        }

        public bool IsItInsuranceCreated(string insuranceId)
        {
            return this.insuranceRepository.AllAsNoTracking().Any(x => x.Id == insuranceId);
        }
    }
}
