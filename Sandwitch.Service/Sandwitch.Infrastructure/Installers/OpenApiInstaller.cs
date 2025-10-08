using System.Net;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Sandwitch.Infrastructure.Installers;

/// <summary>
///     Represents a <see cref="OpenApiInstaller" /> class.
/// </summary>
public static class OpenApiInstaller
{
    /// <summary>
    ///     Installs Open Api
    /// </summary>
    /// <param name="this">Injected <see cref="IServiceCollection" /></param>
    public static void InstallOpenApi(this IServiceCollection @this)
    {
        @this.AddEndpointsApiExplorer();
        
        @this.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Sandwitch.Service"
            });
            options.SwaggerDoc("v2", new OpenApiInfo
            {
                Version = "v2",
                Title = "Sandwitch.Service"
            });
            var xmlFilename = "Sandwitch.Service.xml";
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            options.AddSecurityDefinition(nameof(AuthenticationSchemes.Basic), new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = nameof(AuthenticationSchemes.Basic),
                In = ParameterLocation.Header,
                Description = "Basic Authorization header using the Basic scheme."
            });
            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = nameof(AuthenticationSchemes.Basic)
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });
    }
}