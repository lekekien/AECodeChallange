using AE.Common.Exceptions;
using Newtonsoft.Json;
using System.Net;

namespace AE.Api.Middlewares
{
    public class ExeptionMiddleware
    {
        private readonly RequestDelegate _next;
        public ExeptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }
        private async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            if (ex is CustomValidationException validationEx)
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                httpContext.Response.ContentType = "application/json";
                await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(new { ex.Message, validationEx.Errors }));
                return;
            }
        }
    }
}
