using Grpc.Net.Client;
using DeliveryDB;
using DeliveryModels.DbManagers.RestaurantManagers;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using DeliveryServer.Managers;

var builder = WebApplication.CreateBuilder(args);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddTransient<CustomerManager>();
builder.Services.AddSingleton(GrpcChannel.ForAddress(builder.Configuration.GetSection("GrpcServices")["CustomerService"]));
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
