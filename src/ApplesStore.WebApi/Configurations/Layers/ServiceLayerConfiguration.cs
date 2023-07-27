using AppleStore.Service.Interfaces.Auth;
using AppleStore.Service.Interfaces.Categories;
using AppleStore.Service.Interfaces.Common;
using AppleStore.Service.Interfaces.Deliveries;
using AppleStore.Service.Interfaces.Discounts;
using AppleStore.Service.Interfaces.Notifications;
using AppleStore.Service.Services.Auth;
using AppleStore.Service.Services.Categories;
using AppleStore.Service.Services.Common;
using AppleStore.Service.Services.Deliveries;
using AppleStore.Service.Services.Discounts;
using AppleStore.Service.Services.Notifications;

namespace AppleStore.WebApi.Configurations.Layers;

public static class ServiceLayerConfiguration
{
    public static void ConfigureServiceLayer(this WebApplicationBuilder builder)
    {
        //-> DI containers, IoC containers
        builder.Services.AddScoped<IFileService, FileService>();
        builder.Services.AddScoped<ICategoryService, CategoryService>();
        builder.Services.AddScoped<IAuthService, AuthService>();
        builder.Services.AddScoped<ITokenService, TokenService>();
        builder.Services.AddScoped<IPaginator, Paginator>();
        builder.Services.AddSingleton<ISmsSender, SmsSender>();
        builder.Services.AddScoped<IDeliveryService, DeliveryService>();
        builder.Services.AddScoped<IDiscountService, DiscountService>();
    }
}
