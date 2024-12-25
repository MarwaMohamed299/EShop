var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblies(typeof(Program).Assembly);
});
builder.Services.AddMarten(opts =>
{
    var ConnectionString = builder.Configuration.GetConnectionString("DataBase");
    opts.Connection(ConnectionString!);
}).UseLightweightSessions();  //Lightweight sessions for performane in CRUD

#region Config
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapCarter();

app.Run();
