using BuildingBlocks.Exceptions.Handler;

var builder = WebApplication.CreateBuilder(args);

#region Services
builder.Services.AddCarter();

var assemly = typeof(Program).Assembly;

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblies(assemly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
    config.AddOpenBehavior(typeof(LoggingBehavior<,>));
});

builder.Services.AddValidatorsFromAssembly(assemly);

builder.Services.AddMarten(opts =>
{
    var ConnectionString = builder.Configuration.GetConnectionString("DataBase");
    opts.Connection(ConnectionString!);
}).UseLightweightSessions();  //Lightweight sessions for performane in CRUD

builder.Services.AddExceptionHandler<CustomExceptionHandler>();

#endregion

#region Config
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endregion

#region Middlewares
var app = builder.Build();

app.MapCarter();

app.UseExceptionHandler(options => { });

app.Run();

#endregion