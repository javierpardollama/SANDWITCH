
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;

using Sandwitch.Tier.Authentication.Classes;
using Sandwitch.Tier.Settings.Classes;

using System.Net;

namespace Sandwitch.Tier.Service.Extensions
{
    /// <summary>
    /// Represents a <see cref="AuthenticationExtension"/> class.
    /// </summary>
    public static class AuthenticationExtension
    {
        /// <summary>
        /// Extends Customized Authentication
        /// </summary>
        /// <param name="this">Injected <see cref="IServiceCollection"/></param>
        /// <param name="ApiSettings">Injected <see cref="ApiSettings"/></param>
        public static void AddCustomizedAuthentication(this IServiceCollection @this, ApiSettings @ApiSettings)
        {
            @this.AddAuthentication(AuthenticationSchemes.Basic.ToString())
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>(AuthenticationSchemes.Basic.ToString(),
                                                                                    options => options.ClaimsIssuer = @ApiSettings.ApiIssuer);
        }
    }
}
