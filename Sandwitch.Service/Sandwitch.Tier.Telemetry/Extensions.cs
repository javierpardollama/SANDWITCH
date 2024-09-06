using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.ServiceDiscovery;

using OpenTelemetry;
using OpenTelemetry.Metrics;
using OpenTelemetry.Trace;

using System;

namespace Microsoft.Extensions.Hosting
{
    // Adds common .NET Aspire services: service discovery, resilience, health checks, and OpenTelemetry.
    // This project should be referenced by each service project in your solution.
    // To learn more about using this project, see https://aka.ms/dotnet/aspire/service-defaults
    public static class Extensions
    {
        public static IHostApplicationBuilder AddCustomizedAspireServices(this IHostApplicationBuilder @builder)
        {
            @builder.ConfigureOpenTelemetry();

            @builder.AddDefaultHealthChecks();

            @builder.Services.AddServiceDiscovery();

            @builder.Services.ConfigureHttpClientDefaults(http =>
            {
                // Turn on resilience by default
                http.AddStandardResilienceHandler();

                // Turn on service discovery by default
                http.AddServiceDiscovery();
            });

            // Uncomment the following to restrict the allowed schemes for service discovery.
            @builder.Services.Configure<ServiceDiscoveryOptions>(options =>
            {
                options.AllowedSchemes = ["https"];
            });

            return @builder;
        }

        private static IHostApplicationBuilder ConfigureOpenTelemetry(this IHostApplicationBuilder @builder)
        {
            @builder.Logging.AddOpenTelemetry(logging =>
            {
                logging.IncludeFormattedMessage = true;
                logging.IncludeScopes = true;
            });

            @builder.Services.AddOpenTelemetry()
                .WithMetrics(metrics =>
                {
                    metrics.AddAspNetCoreInstrumentation()
                        .AddHttpClientInstrumentation()
                        .AddRuntimeInstrumentation();
                })
                .WithTracing(tracing =>
                {
                    tracing.AddAspNetCoreInstrumentation()
                        // Uncomment the following line to enable gRPC instrumentation (requires the OpenTelemetry.Instrumentation.GrpcNetClient package)
                        //.AddGrpcClientInstrumentation()
                        .AddHttpClientInstrumentation();
                });

            @builder.AddOpenTelemetryExporters();

            return builder;
        }

        private static IHostApplicationBuilder AddOpenTelemetryExporters(this IHostApplicationBuilder @builder)
        {
            var useOtlpExporter = !string.IsNullOrWhiteSpace(@builder.Configuration["OTEL_EXPORTER_OTLP_ENDPOINT"]);

            if (useOtlpExporter)
            {
                @builder.Services.AddOpenTelemetry().UseOtlpExporter();
            }

            // Uncomment the following lines to enable the Azure Monitor exporter (requires the Azure.Monitor.OpenTelemetry.AspNetCore package)
            //if (!string.IsNullOrEmpty(builder.Configuration["APPLICATIONINSIGHTS_CONNECTION_STRING"]))
            //{
            //    builder.Services.AddOpenTelemetry()
            //       .UseAzureMonitor();
            //}

            return @builder;
        }

        private static IHostApplicationBuilder AddDefaultHealthChecks(this IHostApplicationBuilder @builder)
        {
            // Adding health checks endpoints to applications in non-development environments has security implications.
            // See https://aka.ms/dotnet/aspire/healthchecks for details before enabling these endpoints in non-development environments.
            @builder.Services.AddRequestTimeouts(configure: static timeouts => timeouts.AddPolicy("HealthChecks", TimeSpan.FromSeconds(5)));

            @builder.Services.AddOutputCache(configureOptions: static caching => caching.AddPolicy("HealthChecks", build: static policy => policy.Expire(TimeSpan.FromSeconds(10))));

            @builder.Services.AddHealthChecks()
                // Add a default liveness check to ensure app is responsive
                .AddCheck("self", () => HealthCheckResult.Healthy(), ["live"]);

            return @builder;
        }

        public static WebApplication MapDefaultHealthEndpoints(this WebApplication @app)
        {

            @app.MapGroup("").CacheOutput("HealthChecks").WithRequestTimeout("HealthChecks");

            // All health checks must pass for app to be
            // considered ready to accept traffic after starting
            @app.MapHealthChecks("/health");

            // Only health checks tagged with the "live" tag
            // must pass for app to be considered alive
            @app.MapHealthChecks("/alive", new()
            {
                Predicate = static r => r.Tags.Contains("live")
            });          

            return @app;
        }
    }
}
