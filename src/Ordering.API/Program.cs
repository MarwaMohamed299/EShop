using Ordering.API;
using Ordering.Application;
using Ordering.Infrastructure;
using Ordering.Infrastructure.Extenions;


var builder = WebApplication.CreateBuilder(args);

// Add Services to container

builder.Services
    .AddApiServices(builder.Configuration)
    .AddApplicationServices(builder.Configuration)
    .AddInfrastructureServices(builder.Configuration);


var app = builder.Build();

// Configure Http Requests
app.UseApiServices();

 if (app.Environment.IsDevelopment())
{
    await app.InitialiseDatabaseAsync();
}
app.Run();
