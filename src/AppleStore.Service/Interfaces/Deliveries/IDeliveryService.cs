using AppleStore.DataAccess.Utils;
using AppleStore.Domain.Entities.Deliveries;
using AppleStore.Service.Dtos.Deliveries;

namespace AppleStore.Service.Interfaces.Deliveries;

public interface IDeliveryService
{
    public Task<bool> CreateAsync(DeliveryCreateDto dto);

    public Task<IList<Delivery>> GetAllAsync(PaginationParams @params);

    public Task<Delivery> GetByIdAsync(long deliveryId);

    public Task<bool> DeleteAsync(long deliveryId);
}
