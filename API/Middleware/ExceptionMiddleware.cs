using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly IHostEnvironment _env;
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware>_logger;
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger,
        IHostEnvironment env)
        {
            _env = env;
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try {
                await _next(context);
            }catch(System.Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = 500;

                var response = new ProblemDetails{
                    Status = 500,
                    Detail = _env.IsDevelopment() ? ex.StackTrace.ToString() : null,
                    Title = ex.Message
                };

                var options = new JsonSerializerOptions{PropertyNamingPolicy  = JsonNamingPolicy.CamelCase};
                var json = JsonSerializer.Serialize(response, options);
                await context.Response.WriteAsync(json);
            }
        }
    }
}