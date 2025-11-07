using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Sandwitch.Application.Installers;
using Sandwitch.Infrastructure.Installers;
using System.Text.Json.Serialization;

var @builder = WebApplication.CreateBuilder(args);

// Add services to the container.

@builder.Services.InstallEntityFramework(@builder.Configuration);

@builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.WriteIndented = true;
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
    });

@builder.Services.InstallApiVersions();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
@builder.Services.InstallOpenApi();

// Register the Mapping Profiles
@builder.Services.InstallAutoMapper();

// Register the service and implementation for the database context
@builder.Services.InstallManagers();
@builder.Services.InstallMediatR();

// Register the Mvc services to the services container
@builder.Services.AddResponseCaching();

var @apiSettings = @builder.InstallApiSetttings();
var @rateSettings = @builder.InstallRateLimitSettings();

// Add customized Authentication to the services container.
@builder.Services.InstallIdentification(apiSettings);
@builder.Services.InstallCors(apiSettings);

@builder.Services.InstallProblemDetails();
@builder.Services.InstallRateLimiter(@rateSettings);

@builder.InstallAspireServices();

@builder.InstallSecureApi();

var @app = @builder.Build();

// Learn more about configuring app pipeline at https://learn.microsoft.com/en-us/aspnet/core/fundamentals/middleware/?view=aspnetcore-8.0
@app.UseOpenApi();

@app.UseMigrations();

@app.UseMiddlewares();

@app.UseSecureApi();

@app.UseCors();

@app.UseIdentification();

@app.UseResponseCaching();

@app.UseRateLimiter();

@app.MapControllers();

@app.UseDefaultHealthEndpoints();

@app.UseRequestTimeouts();
@app.UseOutputCache();

// Return the body of the response when the status code is not successful (the default behavior is to return an empty body with a Status Code)
app.UseProblemDetails();

app.Run();