using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetJwtPractice.Models.Requests
{
    public class GetFilteredPostsRequest
    {
        public string? UserGUID { get; set; }
        public string? CategoryGUID { get; set; }
    }
}
