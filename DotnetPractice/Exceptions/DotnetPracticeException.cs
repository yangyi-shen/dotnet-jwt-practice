using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetPractice.Exceptions
{
    public class DotnetPracticeException : Exception
    {
        public DotnetPracticeExceptionCode Code { get; }

        public DotnetPracticeException(DotnetPracticeExceptionCode code)
            : base(code.Message)
        {
            Code = code;
        }
    }
}
