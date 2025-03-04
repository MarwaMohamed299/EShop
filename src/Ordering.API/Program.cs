using Ordering.API;
using Ordering.Application;
using Ordering.Infrastructure;
using Ordering.Infrastructure.Extenions;


var builder = WebApplication.CreateBuilder(args);

// Add Services to container

builder.Services
    .AddApplicationServices()
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices();

var app = builder.Build();
Console.WriteLine("Test");

// Configure Http Requests
app.UseApiServices();

 if (app.Environment.IsDevelopment())
{
    await app.InitialiseDatabaseAsync();
}
app.Run();
