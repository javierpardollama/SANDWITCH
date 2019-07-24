﻿using System;
using System.Net;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;

using Newtonsoft.Json;

using Sandwitch.Tier.ViewModels.Classes.Views;

namespace Sandwitch.Tier.ExceptionHandling.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate RequestDelegate;

        public ExceptionMiddleware(RequestDelegate request) => RequestDelegate = request;

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await RequestDelegate(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleExceptionAsync(
            HttpContext context,
            Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            ViewException viewException = new ViewException
            {
                StatusCode = context.Response.StatusCode,
                Message = exception.Message
            };

            return context.Response.WriteAsync(JsonConvert.SerializeObject(viewException));
        }
    }
}