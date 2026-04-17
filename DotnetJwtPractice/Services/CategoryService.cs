using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetJwtPractice.Exceptions;
using DotnetJwtPractice.Models.DTOs;
using DotnetJwtPractice.Models.Entities;
using DotnetJwtPractice.Models.Requests;
using DotnetJwtPractice.Repository;
using DotnetJwtPractice.Utils;

namespace DotnetJwtPractice.Services
{
    public class CategoryService
    {
        private readonly CategoryUtils _utils = new();
        private readonly CategoryRepository _repository;

        public CategoryService(CategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<ApiResponse<List<Category>>> GetAllCategories()
        {
            List<Category> data = await _repository.GetAllCategories();

            ApiResponse<List<Category>> response = new(true, data);

            return response;
        }

        public async Task<ApiResponse<Category>> AddCategory(AddCategoryRequest request)
        {
            string categoryName = request.CategoryName;
            if (!_utils.validateCategoryName(categoryName))
            {
                throw new ApiException(ApiExceptions.CATEGORY_INVALID);
            }

            Category? existingCategory = await _repository.GetCategoryByCategoryName(categoryName);
            if (existingCategory != null)
            {
                throw new ApiException(ApiExceptions.CATEGORY_ALREADY_EXISTS);
            }

            Category data = new(categoryName);
            await _repository.AddCategory(data);

            ApiResponse<Category> response = new(true, data);

            return response;
        }
    }
}
