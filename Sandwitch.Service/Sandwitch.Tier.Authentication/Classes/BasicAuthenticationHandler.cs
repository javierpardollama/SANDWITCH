using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using Sandwitch.Tier.Authentication.Interfaces;
using Sandwitch.Tier.Helpers.Classes;
using Sandwitch.Tier.Services.Interfaces;
using Sandwitch.Tier.ViewModels.Classes.Auth;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Sandwitch.Tier.Authentication.Classes
{
    /// <summary>
    /// Represents a <see cref="BasicAuthenticationHandler"/> class. Inherits <see cref="AuthenticationHandler{AuthenticationSchemeOptions}"/> Implements <see cref="IBasicAuthenticationHandler"/>
    /// </summary>
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>, IBasicAuthenticationHandler
    {
        /// <summary>
        /// Instance of <see cref="IAuthService"/>
        /// </summary>
        private readonly IAuthService AuthService;

        /// <summary>
        /// Initializes a new Instance of <see cref="BasicAuthenticationHandler"/>
        /// </summary>
        /// <param name="options">Injected <see cref="IOptionsMonitor{AuthenticationSchemeOptions}"/></param>
        /// <param name="logger">Injected <see cref="ILoggerFactory"/></param>
        /// <param name="encoder">Injected <see cref="UrlEncoder"/></param>
        /// <param name="clock">Injected <see cref="ISystemClock"/></param>
        /// <param name="authService">Injected <see cref="IAuthService"/></param>
        public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> @options,
                                          ILoggerFactory @logger,
                                          UrlEncoder @encoder,
                                          ISystemClock @clock,
                                          IAuthService @authService) : base(@options, @logger, @encoder, @clock)
        {
            this.AuthService = @authService;
        }

        /// <summary>
        /// Gets Authentication Ticket
        /// </summary>
        /// <param name="authSignIn">Injected <see cref="AuthSignIn"/></param>
        /// <returns>Instance of <see cref="AuthenticationTicket"/></returns>
        public AuthenticationTicket GetAuthenticationTicket(AuthSignIn @authSign)
        {
            List<Claim> @claims = new()
            {               
                 new Claim(ClaimTypes.Name, @authSign.UserName),
                 new Claim(ClaimTypes.Locality, CultureInfo.CurrentCulture.TwoLetterISOLanguageName),
                 new Claim(ClaimTypes.System, Environment.MachineName),
            };

            return new AuthenticationTicket(
                new ClaimsPrincipal(identity: new ClaimsIdentity(claims: @claims,
                                                                 authenticationType: Scheme.Name)),
                authenticationScheme: Scheme.Name);
        }

        /// <summary>
        /// Handles Authentication Asynchronously
        /// </summary>
        /// <returns></returns>
        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return Task.FromResult(AuthenticateResult.Fail("Authorization Error. Header Not Found"));
            }
            else
            {
                return AuthService.CanAuthenticate(CredentialHelper.GetRequestCredentials(Request))
                    ? Task.FromResult(AuthenticateResult.Success(ticket: GetAuthenticationTicket(authSign: CredentialHelper.GetRequestCredentials(Request))))
                    : Task.FromResult(AuthenticateResult.Fail("Authorization Error. Authentication Error"));
            }
        }
    }
}
