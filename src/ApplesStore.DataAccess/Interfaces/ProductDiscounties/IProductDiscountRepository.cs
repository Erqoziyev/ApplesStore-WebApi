using AppleStore.DataAccess.Common.Interfaces;
using AppleStore.DataAccess.Utils;
using AppleStore.Domain.Entities.Products;

namespace AppleStore.DataAccess.Interfaces.ProductDiscounties;

public interface IProductDiscountRepository : IRepository<ProductDiscount, ProductDiscount>,
                 IGetAll<ProductDiscount>, ISearchable<ProductDiscount>
{
}
