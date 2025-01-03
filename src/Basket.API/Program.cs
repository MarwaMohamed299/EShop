var builder = WebApplication.CreateBuilder(args);

//Add Services


var app = builder.Build();

app.MapGet("/", () => "Hello World!");

// Configure Http request

app.Run();
