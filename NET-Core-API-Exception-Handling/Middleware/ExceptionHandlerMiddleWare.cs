using Microsoft.AspNetCore.Http;
using NET_Core_API_Exception_Handling.Application.Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace NET_Core_API_Exception_Handling.Middleware
{
    public class ExceptionHandlerMiddleWare
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleWare(RequestDelegate next)
        {
            _next = next;
        }


        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {

                await ConvertException(context, ex);
            }
        }

        private Task ConvertException(HttpContext context, Exception ex)
        {
            HttpStatusCode httpsStatusCode = HttpStatusCode.InternalServerError;

            context.Response.ContentType = "application/json";

            var result = string.Empty;

            // map the custom exception type to the correspnding StatausCode
            // then serialize any error messages to go along trhe response.
            switch (ex)
            {
                case ModelNotValidException validationException:
                    httpsStatusCode = HttpStatusCode.BadRequest;
                    result = JsonConvert.SerializeObject(validationException.Errors);
                    break;
                case ModelNotFoundException notFoundException:
                    httpsStatusCode = HttpStatusCode.NotFound;
                    result = JsonConvert.SerializeObject(notFoundException.Message);
                    break;
                default:
                    httpsStatusCode = HttpStatusCode.BadRequest;
                    break;
            }

            context.Response.StatusCode = (int)httpsStatusCode;

            if (result == string.Empty)
            {
                result = JsonConvert.SerializeObject(new { error = ex.Message });

            }

            return context.Response.WriteAsync(result);
        }


    }
}
