using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DotnetJwtPractice.Models.DTOs;
using DotnetJwtPractice.Models.Entities;
using DotnetJwtPractice.Models.Requests;
using DotnetJwtPractice.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotnetJwtPractice.Controllers
{
    [ApiController]
    [Route("api/posts")]
    [Authorize]
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
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }

            ApiResponse<Post> response = await _service.AddPost(userId, request);
            return Ok(response);
        }
    }
}
