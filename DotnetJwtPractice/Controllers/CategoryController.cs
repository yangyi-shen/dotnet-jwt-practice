using System;
using System.Collections.Generic;
using System.Linq;
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
    [Route("api/categories")]
    // chính sách mặc định cho controller này thôi, chứ có vài endpoint sẽ chỉ cho Admin gọi
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService _service;

        public CategoryController(CategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<Category>>>> GetAllCategories()
        {
            ApiResponse<List<Category>> response = await _service.GetAllCategories();
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ApiResponse<Category>>> AddCategory(
            AddCategoryRequest request
        )
        {
            ApiResponse<Category> response = await _service.AddCategory(request);
            return Ok(response);
        }
    }
}
