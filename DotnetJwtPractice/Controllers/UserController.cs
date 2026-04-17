using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetJwtPractice.Models;
using DotnetJwtPractice.Models.DTOs;
using DotnetJwtPractice.Models.Requests;
using DotnetJwtPractice.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotnetJwtPractice.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly UserService _service;

        public UserController(UserService service)
        {
            _service = service;
        }

        [HttpPost("register")]
        public async Task<ActionResult<ApiResponse<User>>> RegisterUser(RegisterRequest request)
        {
            ApiResponse<User> response = await _service.RegisterUser(request);
            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<ActionResult<ApiResponse<User>>> LoginUser(LoginRequest request)
        {
            ApiResponse<User> response = await _service.LoginUser(request);
            return Ok(response);
        }
    }
}
