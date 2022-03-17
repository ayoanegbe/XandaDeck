using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace XandaDeck.Core.Services
{
    public class RequestHeaderMiddleware
    {
        private readonly RequestDelegate _next;
        public RequestHeaderMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            string url = context.Request.Path;

            if (url.Contains("api"))
            {
                if (context.Request.Headers["user-key"] != "4392a7200e7541eba7a1d4ea610ace82")
                {
                    context.Response.StatusCode = 401; //UnAuthorized
                    await context.Response.WriteAsync("Invalid User");
                    return;
                }

            }

            await _next.Invoke(context);
        }
    }
}
