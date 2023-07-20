using AppleStore.DataAccess.Common.Interfaces;
using AppleStore.Domain.Entities.Discounts;

namespace AppleStore.DataAccess.Interfaces.Discounts;

public interface IDiscountRepository : IRepository<Discount, Discount>, IGetAll<Discount>
{
}
