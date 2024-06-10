﻿using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace Sandwitch.Tier.Middlewares.Middlewares
{
    /// <summary>
    /// Represents a <see cref="HeaderMiddleware"/> class
    /// </summary>
    /// <param name="request">Injected <see cref="RequestDelegate"/></param>
    public class HeaderMiddleware(RequestDelegate @request)
    {     

        /// <summary>
        /// Handles Requests Asynchronously
        /// </summary>
        /// <param name="context">Injected <see cref="HttpContext"/></param>
        /// <returns>Instance of <see cref="Task"/></returns>
        public async Task InvokeAsync(HttpContext @context)
        {
            @context.Response.Headers.Remove("X-Powered-By");
            @context.Response.Headers.Remove("Server");
            @context.Response.Headers.XContentTypeOptions = new StringValues("nosniff");
            @context.Response.Headers.XFrameOptions = new StringValues("deny");
            @context.Response.Headers.XXSSProtection = new StringValues("0");
            @context.Response.Headers.ContentSecurityPolicy = new StringValues("default-src 'self'");

            await request(@context);
        }
    }
}
