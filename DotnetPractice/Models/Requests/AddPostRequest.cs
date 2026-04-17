using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetJwtPractice.Models.Requests
{
    public class AddPostRequest
    {
        // sữ dụng loại dữ liệu string để dời trách nhiệm xác thực guid từ .NET sang ứng dụng mình
        public required string UserGUID { get; set; }
        public required string CategoryGUID { get; set; }
        public required string PostText { get; set; }
    }
}
