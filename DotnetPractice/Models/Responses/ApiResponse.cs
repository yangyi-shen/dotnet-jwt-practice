using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetPractice.Models.DTOs
{
    public class ApiResponse<T>
    {
        public bool Status { get; set; }
        public T Data { get; set; } = default!;

        public ApiResponse(bool status, T data)
        {
            Status = status;
            Data = data;
        }
    }
}
