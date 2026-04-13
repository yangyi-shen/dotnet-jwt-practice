using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetPractice.Models.Requests
{
    public class AddPostRequest
    {
        public required Guid UserGUID { get; set; }
        public required Guid CategoryGUID { get; set; }
        public required string PostText { get; set; }
    }
}
