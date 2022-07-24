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

using System.Text.Json.Serialization;

var @builder = WebApplication.CreateBuilder(args);

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
@builder.Services.AddSwaggerGen();

// Register the Mapping Profiles
@builder.Services.AddAutoMapper(typeof(ModelingProfile).Assembly);

// Register the service and implementation for the database context
@builder.Services.AddCustomizedContexts();

// Register the Mvc services to the services container
@builder.Services.AddCustomizedServices();

@builder.Services.AddResponseCaching();

var @settings = new ApiSettings();
@builder.Configuration.GetSection("Api").Bind(@settings);
@builder.Services.Configure<ApiSettings>(@builder.Configuration.GetSection("Api"));

// Add customized Authentication to the services container.
@builder.Services.AddCustomizedAuthentication();

@builder.Services.AddCustomizedOrigins(@settings);

@builder.Host.UseSerilog((hostingContext, loggerConfiguration) => loggerConfiguration
                .ReadFrom.Configuration(hostingContext.Configuration));

@builder.Services.AddHealthChecks();

var @app = @builder.Build();

// Configure the HTTP request pipeline.
if (@app.Environment.IsDevelopment())
{
    @app.UseSwagger();
    @app.UseSwaggerUI();

    @app.UseMigrations();
}

@app.UseCustomizedExceptionMiddlewares();

@app.UseHttpsRedirection();

@app.UseAuthentication();
@app.UseAuthorization();

// UseCors must be called before UseResponseCaching
@app.UseCors();

@app.UseResponseCaching();

@app.MapControllers();

@app.MapHealthChecks("/healthz");

@app.Run();
