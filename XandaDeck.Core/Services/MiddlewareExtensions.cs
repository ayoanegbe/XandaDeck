using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace XandaDeck.Core.Services
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestHeaderMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestHeaderMiddleware>();
        }
    }
}

