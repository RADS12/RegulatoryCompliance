using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace RegulatoryCompliance.ExceptionMiddleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex, "Unhandled exception for request {Path}", context.Request.Path);
                context.Response.ContentType = "application/problem+json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var problemDetails = new
                {
                    type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
                    title = "An unexpected error occurred.",
                    status = 500,
                    detail = ex.Message,
                    instance = context.Request.Path,
                    traceId = context.TraceIdentifier
                };
                var json = JsonSerializer.Serialize(problemDetails);
                await context.Response.WriteAsync(json);
            }
        }
    }
}
