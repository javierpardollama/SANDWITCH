using System.Text.Json.Serialization;

using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Sandwitch.Tier.Contexts.Classes;
using Sandwitch.Tier.Mappings.Classes;
using Sandwitch.Tier.Service.Extensions;
using Sandwitch.Tier.Settings.Classes;

using Serilog;

var @builder = WebApplication.CreateBuilder(args);

@builder.AddServiceDefaults();

// Add services to the container.

@builder.Services.AddDbContext<ApplicationContext>(options =>
             options.UseSqlite(@builder.Configuration.GetConnectionString("DefaultConnection")));

@builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                    options.JsonSerializerOptions.PropertyNamingPolicy = null;
                });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
@builder.Services.AddEndpointsApiExplorer();
@builder.Services.AddCustomizedSwagger();

// Register the Mapping Profiles
@builder.Services.AddAutoMapper(typeof(ModelingProfile).Assembly);

// Register the service and implementation for the database context
@builder.Services.AddCustomizedContexts();

// Register the Mvc services to the services container
@builder.Services.AddCustomizedServices();

@builder.Services.AddResponseCaching();

var @Apisettings = new ApiSettings();
@builder.Configuration.GetSection("Api").Bind(@Apisettings);
@builder.Services.Configure<ApiSettings>(@builder.Configuration.GetSection("Api"));

// Add customized Authentication to the services container.
@builder.Services.AddCustomizedAuthentication(@Apisettings);

@builder.Services.AddCustomizedCrossOriginRequests(@Apisettings);

@builder.Host.UseSerilog((hostingContext, loggerConfiguration) => loggerConfiguration
                .ReadFrom.Configuration(hostingContext.Configuration));

@builder.Services.AddHealthChecks();

// Register the Rate Limit Settings to the configuration container.
var @RateSettings = new RateLimitSettings();
@builder.Configuration.GetSection("RateLimit").Bind(@RateSettings);
@builder.Services.Configure<RateLimitSettings>(@builder.Configuration.GetSection("RateLimit"));

@builder.Services.AddCustomizedRateLimiter(@RateSettings);


var @app = @builder.Build();

@app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (@app.Environment.IsDevelopment())
{
    @app.UseSwagger();
    @app.UseSwaggerUI();

    @app.UseMigrations();
}

@app.UseCustomizedMiddlewares();

@app.UseHttpsRedirection();

// UseCors must be called before UseResponseCaching, UseAuthentication, UseAuthorization
@app.UseCors();

@app.UseAuthentication();
@app.UseAuthorization();

@app.UseResponseCaching();

@app.UseRateLimiter();

@app.MapControllers();

@app.Run();
