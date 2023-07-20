using AppleStore.DataAccess.Common.Interfaces;
using AppleStore.DataAccess.Utils;
using AppleStore.DataAccess.ViewModels.Products;
using AppleStore.Domain.Entities.Products;

namespace AppleStore.DataAccess.Interfaces.Products;

public interface IProductRepository : IRepository<Product, ProductViewModel>,
                 IGetAll<ProductViewModel>, ISearchable<ProductViewModel>
{
}
