using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Net;
using System.Reflection;

namespace Sandwitch.Tier.Service.Extensions
{
    /// <summary>
    /// Represents a <see cref="SwaggerExtension"/> class.
    /// </summary>
    public static class SwaggerExtension
    {
        /// <summary>
        /// Extends Customized Swagger Configuration
        /// </summary>
        /// <param name="this">Injected <see cref="IServiceCollection"/></param>        
        public static void AddCustomizedSwagger(this IServiceCollection @this)
        {
            @this.AddSwaggerGen(options =>
            {
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
                options.AddSecurityDefinition(AuthenticationSchemes.Basic.ToString(), new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = AuthenticationSchemes.Basic.ToString(),
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
                                    Id = AuthenticationSchemes.Basic.ToString()
                                }
                          },
                          Array.Empty<string>()
                    }
                });
            });
        }
    }
}
