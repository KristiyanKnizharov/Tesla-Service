namespace TeslaService.Web.ViewModels.Service
{
    using System.Collections.Generic;

    using TeslaService.Web.ViewModels.Employee;
    using TeslaService.Web.ViewModels.Vehicle;

    public class GetServiceModel
    {
        public int Id { get; set; }

        public int WarehouseId { get; set; }

        public IEnumerable<EmployeeModel> Employees { get; set; }

        public IEnumerable<InfoVehicleModel> Vehicles { get; set; }
    }
}
