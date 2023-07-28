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
using AppleStore.WebApi.Configurations;
using AppleStore.WebApi.Configurations.Layers;
using AppleStore.WebApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddMemoryCache();
builder.ConfigureJwtAuth();
builder.ConfigureSwaggerAuth();
builder.ConfigureCORSPolicy();
builder.ConfigureDataAccess();
builder.ConfigureServiceLayer();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseStaticFiles();
app.UseMiddleware<ExceptionHandlerMiddleware>();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
