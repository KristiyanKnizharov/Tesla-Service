namespace TeslaService.Services.Data.Common
{
    public interface IHomeService
    {
        int CountParts();

        int CountTypesOfParts();

        int CountUsers();

        int CountVehicles();

        int CountBatteries();

        int CountEmployees();
    }
}
