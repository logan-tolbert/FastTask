using FastEndpoints;
using FastEndpoints.Swagger;
using FastTask.TaskItems.Extensions;
using Serilog;
using Serilog.Events;

var logger = Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateBootstrapLogger();

try
{
    Log.Information("Starting web application");

    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddSerilog((services, lc) => lc
    .ReadFrom.Configuration(builder.Configuration)
    .ReadFrom.Services(services)
    .Enrich.FromLogContext()
    .WriteTo.Console());

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddFastEndpoints()
        .SwaggerDocument();
    builder.Services.AddCors(opts =>
    {
        opts.AddPolicy("AllowAngularClient", policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
    });

    builder.Services.AddTaskItemsService(builder.Configuration, logger);

    var app = builder.Build();

    app.UseCors("AllowAngularClient");

    app.UseFastEndpoints()
        .UseSwaggerGen();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}

public partial class Program { }