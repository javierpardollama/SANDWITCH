﻿using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;

using Sandwitch.Tier.ViewModels.Classes.Views;

namespace Sandwitch.Tier.Middlewares.Middlewares
{
    /// <summary>
    /// Represents a <see cref="ExceptionMiddleware"/> class
    /// </summary>
    /// <param name="request">Injected <see cref="RequestDelegate"/></param>
    public class ExceptionMiddleware(RequestDelegate @request)
    {      
        /// <summary>
        /// Invoques Asynchronously
        /// </summary>
        /// <param name="context">Injected <see cref="HttpContext"/></param>
        /// <returns>Instance of <see cref="Task"/></returns>
        public async Task InvokeAsync(HttpContext @context)
        {
            try
            {
                await @request(@context);
            }
            catch (Exception @exception)
            {
                await HandleExceptionAsync(@context, @exception);
            }
        }

        /// <summary>
        /// Handles Exception Asynchronously
        /// </summary>
        /// <param name="context">Injected <see cref="HttpContext"/></param>
        /// <param name="exception">Injected <see cref="Exception"/></param>
        /// <returns>Instance of <see cref="ViewException"/></returns>
        private static Task HandleExceptionAsync(
            HttpContext @context,
            Exception @exception)
        {
            @context.Response.ContentType = "application/json";
            @context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            ViewException @viewException = new()
            {
                StatusCode = @context.Response.StatusCode,
                Message = @exception.Message
            };

            return @context.Response.WriteAsJsonAsync<ViewException>(@viewException, new JsonSerializerOptions() { WriteIndented = true });
        }
    }
}