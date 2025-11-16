using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi;
using System.Net;

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
                Version = "1.0",
                Title = "Sandwitch.Service 1.0",
            });
            options.SwaggerDoc("v2", new OpenApiInfo
            {
                Version = "2.0",
                Title = "Sandwitch.Service 2.0",
            });
            options.DocInclusionPredicate((name, description) => description.GroupName == name);
            options.ResolveConflictingActions(descriptions => descriptions.First());

            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Sandwitch.Service.xml"));
            options.AddSecurityDefinition(nameof(AuthenticationSchemes.Basic), new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = nameof(AuthenticationSchemes.Basic),
                In = ParameterLocation.Header,
                Description = "Basic Authorization header using the Basic scheme."
            });


            options.AddSecurityRequirement((document) => new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecuritySchemeReference(nameof(AuthenticationSchemes.Basic),
                                                       document),
                    ["read", "write"]
                }
            });           
        });
    }

    /// <summary>
    ///     Uses Open Api
    /// </summary>
    /// <param name="this">Injected <see cref="WebApplication" /></param>
    public static void UseOpenApi(this WebApplication @this)
    {
        if (@this.Environment.IsDevelopment())
        {
            @this.UseSwagger(options =>
            {
                options.OpenApiVersion = OpenApiSpecVersion.OpenApi3_1;
            });

            @this.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.SwaggerEndpoint("/swagger/v2/swagger.json", "v2");
            });
        }
    }
}