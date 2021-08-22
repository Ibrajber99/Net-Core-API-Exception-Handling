using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_Core_API_Exception_Handling.Middleware
{
    public static class MiddleWareExtension
    {
        public static IApplicationBuilder UserCustomeExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlerMiddleWare>();
        }
    }
}
