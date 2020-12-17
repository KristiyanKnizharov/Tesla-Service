namespace TeslaService.Web.ViewModels.Insurance
{
    using System.ComponentModel.DataAnnotations;

    public class InfoInsuranceModel
    {
        public string Id { get; set; }

        [MaxLength(30)]
        public string VinNumber { get; set; }

        public string DateOfStart { get; set; }

        public string DateOfEnd { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }
    }
}
