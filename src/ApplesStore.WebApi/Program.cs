using AppleStore.DataAccess.Interfaces.Categories;
using AppleStore.DataAccess.Interfaces.Deliveries;
using AppleStore.DataAccess.Repositories.Categories;
using AppleStore.DataAccess.Repositories.Deliveries;
using AppleStore.Service.Interfaces.Categories;
using AppleStore.Service.Interfaces.Common;
using AppleStore.Service.Interfaces.Deliveries;
using AppleStore.Service.Services.Categories;
using AppleStore.Service.Services.Common;
using AppleStore.Service.Services.Deliveries;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IDeliveryRepository, DeliveryRepository>();

builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IDeliveryService, DeliveryService>();

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
