namespace TeslaService.Services.Data.Contracts
{
    public interface IWarehouseService
    {
        void CreateWarehouseAsync(int id);

        void DeleteWarehouseAsync(int id);

        bool IsItWarehouseCreated(int id);
    }
}
