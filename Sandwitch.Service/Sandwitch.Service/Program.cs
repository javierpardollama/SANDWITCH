using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sandwitch.Application.Installers;
using Sandwitch.Domain.Settings;
using Sandwitch.Host.Installers;
using Sandwitch.Infrastructure.Installers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.InstallEntityFramework(builder.Configuration);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.WriteIndented = true;
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.InstallOpenApi();

// Register the Mapping Profiles
builder.Services.InstallAutoMapper();

// Register the service and implementation for the database context
builder.Services.InstallManagers();
builder.Services.InstallMediatR();

// Register the Mvc services to the services container
builder.Services.AddResponseCaching();

var ApiSettings = new ApiSettings();
builder.Configuration.GetSection("Api").Bind(ApiSettings);
builder.Services.Configure<ApiSettings>(builder.Configuration.GetSection("Api"));

// Add customized Authentication to the services container.
builder.Services.InstallAuthentication(ApiSettings);
builder.Services.InstallCors(ApiSettings);

// Register the Rate Limit Settings to the configuration container.
var RateSettings = new RateLimitSettings();
builder.Configuration.GetSection("RateLimit").Bind(RateSettings);
builder.Services.Configure<RateLimitSettings>(builder.Configuration.GetSection("RateLimit"));

builder.Services.InstallProblemDetails();
builder.Services.InstallRateLimiter(RateSettings);

builder.InstallAspireServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.InstallMigrations();

app.InstallMiddlewares();

app.UseHttpsRedirection();

// Learn more about configuring app pipeline at https://learn.microsoft.com/en-us/aspnet/core/fundamentals/middleware/?view=aspnetcore-8.0
app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

app.UseResponseCaching();

app.UseRateLimiter();

app.MapControllers();

app.InstallDefaultHealthEndpoints();

app.UseRequestTimeouts();
app.UseOutputCache();

// Return the body of the response when the status code is not successful (the default behavior is to return an empty body with a Status Code)
app.UseExceptionHandler();
app.UseStatusCodePages();

app.Run();