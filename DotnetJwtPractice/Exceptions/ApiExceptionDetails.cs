using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetJwtPractice.Exceptions
{
    public record ApiExceptionDetails(int Code, string Message);
}
