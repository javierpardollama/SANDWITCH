using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Sandwitch.Tier.Exceptions.Classes;
using Sandwitch.Tier.ViewModels.Classes.Views;
using System.Net;
using System.Threading.Tasks;

namespace Sandwitch.Tier.ExceptionHandling.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (ServiceException ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, ServiceException exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            return context.Response.WriteAsync(JsonConvert.SerializeObject(new ViewException
            {
                StatusCode = context.Response.StatusCode,
                Message = exception.Message
            }).ToString());
        }
    }
}