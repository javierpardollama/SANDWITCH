﻿
using Microsoft.AspNetCore.Authentication;

using Sandwitch.Tier.Authentication.Classes;

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
        public static void AddCustomizedAuthentication(this IServiceCollection @this)
        {
            @this.AddAuthentication(AuthenticationSchemes.Basic.ToString()).AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>(AuthenticationSchemes.Basic.ToString(), null);
        }
    }
}
