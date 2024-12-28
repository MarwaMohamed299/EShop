 var builder = WebApplication.CreateBuilder(args);

#region Services
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

builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);
#endregion

#region Config
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endregion

#region Middlewares
var app = builder.Build();

app.MapCarter();

app.Run();

#endregion