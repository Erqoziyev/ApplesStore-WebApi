using AppleStore.DataAccess.Interfaces.Categories;
using AppleStore.DataAccess.Interfaces.Deliveries;
using AppleStore.DataAccess.Interfaces.Discounts;
using AppleStore.DataAccess.Interfaces.ProductDiscounties;
using AppleStore.DataAccess.Interfaces.Products;
using AppleStore.DataAccess.Interfaces.Users;
using AppleStore.DataAccess.Repositories.Categories;
using AppleStore.DataAccess.Repositories.Deliveries;
using AppleStore.DataAccess.Repositories.Discounts;
using AppleStore.DataAccess.Repositories.ProductDiscounts;
using AppleStore.DataAccess.Repositories.Products;
using AppleStore.DataAccess.Repositories.Users;

namespace AppleStore.WebApi.Configurations.Layers;

public static class DataAccessConfiguration
{
    public static void ConfigureDataAccess(this WebApplicationBuilder builder)
    {
        //-> DI containers, IoC containers
        builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
        builder.Services.AddScoped<IDeliveryRepository, DeliveryRepository>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IDiscountRepository,  DiscountsRepository>();
        builder.Services.AddScoped<IProductRepository,  ProductRepository>();
        builder.Services.AddScoped<IProductDiscountRepository, ProductDiscountRepository>();
    }
}
