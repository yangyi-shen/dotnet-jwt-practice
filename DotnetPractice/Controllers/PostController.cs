using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetJwtPractice.Models.DTOs;
using DotnetJwtPractice.Models.Entities;
using DotnetJwtPractice.Models.Requests;
using DotnetJwtPractice.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotnetJwtPractice.Controllers
{
    [ApiController]
    [Route("api/posts")]
    public class PostController : ControllerBase
    {
        private readonly PostService _service;

        public PostController(PostService service)
        {
            _service = service;
        }

        [HttpGet("filtered")]
        public async Task<ActionResult<ApiResponse<List<Post>>>> GetFilteredPosts(
            [FromQuery] GetFilteredPostsRequest request
        )
        {
            ApiResponse<List<Post>> response = await _service.GetFilteredPosts(request);
            return Ok(response);
        }

        [HttpPost("add")]
        public async Task<ActionResult<ApiResponse<Post>>> AddPost(AddPostRequest request)
        {
            ApiResponse<Post> response = await _service.AddPost(request);
            return Ok(response);
        }
    }
}
