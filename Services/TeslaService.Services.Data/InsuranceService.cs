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

        public async Task CreateInsuranceAsync(InfoInsuranceModel insuranceModel)
        {
            var insurance = new Insurance()
            {
                Id = insuranceModel.Id,
                VinNumber = insuranceModel.VinNumber,
                DateOfStart = insuranceModel.DateOfStart.ToString("d"),
                DateOfEnd = insuranceModel.DateOfEnd.ToString("d"),
                Description = insuranceModel.Description,
            };
            await this.insuranceRepository.AddAsync(insurance);
            await this.insuranceRepository.SaveChangesAsync();
        }

        public void DeleteInsurance(string insuranceId)
        {
            var insurance = this.insuranceRepository.All().FirstOrDefault(x => x.Id == insuranceId);
            this.insuranceRepository.Delete(insurance);
        }

        public IEnumerable<AllInsuranceModel> GetAllInsurances()
        {
            var insurances = this.insuranceRepository.All().Select(x => new AllInsuranceModel()
            {
                Id = x.Id,
                VinNumber = x.VinNumber,
                DateOfStart = DateTime.UtcNow.ToString("d"),
                DateOfEnd = DateTime.UtcNow.ToString("d"),
                Description = x.Description,
            });

            return insurances;
        }

        public bool IsItInsuranceCreated(string insuranceId)
        {
            return this.insuranceRepository.AllAsNoTracking().Any(x => x.Id == insuranceId);
        }
    }
}
