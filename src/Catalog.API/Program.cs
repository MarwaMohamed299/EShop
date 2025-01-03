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

var ConnectionString = builder.Configuration.GetConnectionString("DataBase");

builder.Services.AddMarten(opts =>
{
    opts.Connection(ConnectionString!);
}).UseLightweightSessions();  //Lightweight sessions for performane in CRUD

if(builder.Environment.IsDevelopment())
{
    builder.Services.InitializeMartenWith<CatalogInitialData>();
}

builder.Services.AddExceptionHandler<CustomExceptionHandler>();

#endregion

#region Config
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks()
    .AddNpgSql(ConnectionString!);
#endregion

#region Middlewares

var app = builder.Build();

app.MapCarter();

app.UseExceptionHandler(options => { });

app.UseHealthChecks("/health",
    new HealthCheckOptions
    {
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse

    });

app.Run();

#endregion