using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetPractice.Exceptions
{
    public class ApiException : Exception
    {
        public ApiExceptionCode Code { get; }

        public ApiException(ApiExceptionCode code)
            : base(code.Message)
        {
            Code = code;
        }
    }
}
