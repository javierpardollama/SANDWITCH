using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Sandwitch.Tier.Contexts.Classes;
using Sandwitch.Tier.Contexts.Interceptors;
using Sandwitch.Tier.Mappings.Classes;
using Sandwitch.Tier.Resilience;
using Sandwitch.Tier.Service.Extensions;
using Sandwitch.Tier.Settings.Classes;

using System.Text.Json.Serialization;

var @builder = WebApplication.CreateBuilder(args);

// Add services to the container.

@builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.AddInterceptors(new SoftDeleteInterceptor());
    options.UseSqlite(@builder.Configuration.GetConnectionString("DefaultConnection"));
});

@builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.WriteIndented = true;
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
@builder.Services.AddCustomizedHandlers(@Apisettings);

@builder.Services.AddCustomizedCrossOriginRequests(@Apisettings);

// Register the Rate Limit Settings to the configuration container.
var @RateSettings = new RateLimitSettings();
@builder.Configuration.GetSection("RateLimit").Bind(@RateSettings);
@builder.Services.Configure<RateLimitSettings>(@builder.Configuration.GetSection("RateLimit"));

@builder.Services.AddCustomizedRateLimiter(@RateSettings);

@builder.AddCustomizedAspireServices();

// Return the Problem Details format for non-successful responses
@builder.Services.AddProblemDetails();

var @app = @builder.Build();

// Configure the HTTP request pipeline.
if (@app.Environment.IsDevelopment())
{
    @app.UseSwagger();
    @app.UseSwaggerUI();

    @app.UseMigrations();
}

@app.UseCustomizedMiddlewares();

@app.UseHttpsRedirection();

// Learn more about configuring app pipeline at https://learn.microsoft.com/en-us/aspnet/core/fundamentals/middleware/?view=aspnetcore-8.0
@app.UseCors();

@app.UseAuthentication();
@app.UseAuthorization();

@app.UseResponseCaching();

@app.UseRateLimiter();

@app.MapControllers();

@app.MapDefaultHealthEndpoints();

@app.UseRequestTimeouts();
@app.UseOutputCache();

// Return the body of the response when the status code is not successful (the default behavior is to return an empty body with a Status Code)
@app.UseExceptionHandler();
@app.UseStatusCodePages();

@app.Run();
