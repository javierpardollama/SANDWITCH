using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Sandwitch.Tier.Handlers.Classes;
using Sandwitch.Tier.Settings.Classes;
using System.Net;

namespace Sandwitch.Tier.Service.Extensions
{
    /// <summary>
    /// Represents a <see cref="HandlerExtension"/> class.
    /// </summary>
    public static class HandlerExtension
    {
        /// <summary>
        /// Extends Customized Authentication
        /// </summary>
        /// <param name="this">Injected <see cref="IServiceCollection"/></param>
        /// <param name="ApiSettings">Injected <see cref="ApiSettings"/></param>
        public static void AddCustomizedHandlers(this IServiceCollection @this, ApiSettings @ApiSettings)
        {
            @this.AddExceptionHandler<ProblemDetailsExceptionHandler>();


            @this.AddAuthentication(AuthenticationSchemes.Basic.ToString())
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>(AuthenticationSchemes.Basic.ToString(),
                                                                                    options => options.ClaimsIssuer = @ApiSettings.ApiIssuer);
        }
    }
}
