
using DeliveryDB;
using DeliveryModels.DbManagers.RestaurantManagers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DeliveryContext>(options => options.UseNpgsql(connection));
builder.Services.AddTransient<RestaurantDbManager>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseDeveloperExceptionPage();

app.UseRouting();
app.MapControllers();

app.Run();
