using AppleStore.DataAccess.Common.Interfaces;
using AppleStore.DataAccess.ViewModels.Deliveries;
using AppleStore.Domain.Entities.Deliveries;

namespace AppleStore.DataAccess.Interfaces.Deliveries;

public interface IDeliveryRepository : IRepository<Delivery, Delivery>,
                 IGetAll<DeliverViewModel>
{
    public Task<DeliverViewModel> GetDeliverAsync(long id);
}
