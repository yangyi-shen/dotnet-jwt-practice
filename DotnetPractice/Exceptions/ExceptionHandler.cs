using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetPractice.Models.DTOs;
using Microsoft.AspNetCore.Diagnostics;

namespace DotnetPractice.Exceptions
{
    public class ExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken
        )
        {
            ApiResponse<ApiExceptionDetails> response = exception switch
            {
                ApiException apiException => new ApiResponse<ApiExceptionDetails>(
                    false,
                    ((ApiException)exception).Details
                ),
                _ => new ApiResponse<ApiExceptionDetails>(false, ApiExceptions.UNEXPECTED_ERROR),
            };

            await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);

            return true;
        }
    }
}
