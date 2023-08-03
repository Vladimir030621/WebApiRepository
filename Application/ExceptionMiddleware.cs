using CommonServices.Models;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace Application
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (ArgumentException ex)
            {
                await Handle(httpContext, ex);
            }
            catch (FluentValidation.ValidationException ex)
            {
                await Handle(httpContext, ex);
            }
            catch (Exception ex)
            {
                await Handle(httpContext, ex);
            }
        }

        private async Task Handle(HttpContext httpContext, ArgumentException ex)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var err = new ApiResponse
            {
                Error = new ApiError
                {
                    Message = ex.Message,
                    Type = "not_valid_argument_error",
                    StatusCode = (int)HttpStatusCode.InternalServerError
                }

            };
            await httpContext.Response.WriteAsJsonAsync(err);
        }

        private async Task Handle(HttpContext httpContext, FluentValidation.ValidationException ex)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var err = new ApiResponse
            {
                Error = new ApiError
                {
                    Message = ex.Message,
                    Type = "validation_error",
                    StatusCode = (int)HttpStatusCode.InternalServerError
                }

            };
            await httpContext.Response.WriteAsJsonAsync(err);
        }

        private async Task Handle(HttpContext httpContext, Exception ex)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var err = new ApiResponse
            {
                Error = new ApiError
                {
                    Message = ex.Message,
                    Type = "common_error",
                    StatusCode = (int)HttpStatusCode.InternalServerError
                }

            };
            await httpContext.Response.WriteAsJsonAsync(err);
        }
    }
}
