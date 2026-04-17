using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetJwtPractice.Exceptions
{
    public class ApiException : Exception
    {
        public ApiExceptionDetails Details { get; }

        public ApiException(ApiExceptionDetails details)
            : base(details.Message)
        {
            Details = details;
        }
    }
}
