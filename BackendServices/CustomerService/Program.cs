using CustomerService.Services;
using DeliveryDB;
using DeliveryModels.DbManagers.RestaurantManagers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DeliveryContext>(options => options.UseNpgsql(connection));
builder.Services.AddTransient<RestaurantDbManager>();
builder.Services.AddGrpc();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<RestaurantService>();
app.Run();

