using AppleStore.DataAccess.Interfaces.Categories;
using AppleStore.DataAccess.Interfaces.Deliveries;
using AppleStore.DataAccess.Interfaces.Users;
using AppleStore.DataAccess.Repositories.Categories;
using AppleStore.DataAccess.Repositories.Deliveries;
using AppleStore.DataAccess.Repositories.Users;
using AppleStore.Service.Interfaces.Auth;
using AppleStore.Service.Interfaces.Categories;
using AppleStore.Service.Interfaces.Common;
using AppleStore.Service.Interfaces.Deliveries;
using AppleStore.Service.Interfaces.Notifications;
using AppleStore.Service.Services.Auth;
using AppleStore.Service.Services.Categories;
using AppleStore.Service.Services.Common;
using AppleStore.Service.Services.Deliveries;
using AppleStore.Service.Services.Notifications;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddMemoryCache();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IDeliveryRepository, DeliveryRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IDeliveryService, DeliveryService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IPaginator, Paginator>();

builder.Services.AddSingleton<ISmsSender, SmsSender>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
