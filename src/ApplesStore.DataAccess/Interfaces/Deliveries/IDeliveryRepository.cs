using AppleStore.DataAccess.Common.Interfaces;
using AppleStore.Domain.Entities.Deliveries;

namespace AppleStore.DataAccess.Interfaces.Deliveries;

public interface IDeliveryRepository : IRepository<Delivery, Delivery>,
                 IGetAll<Delivery>
{
    public Task<Delivery> GetDeliverAsync(long id);
}
