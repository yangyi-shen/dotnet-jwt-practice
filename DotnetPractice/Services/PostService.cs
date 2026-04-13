using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetPractice.Exceptions;
using DotnetPractice.Models.DTOs;
using DotnetPractice.Models.Entities;
using DotnetPractice.Models.Requests;
using DotnetPractice.Repository;
using DotnetPractice.Utils;

namespace DotnetPractice.Services
{
    public class PostService
    {
        private readonly PostUtils _utils = new();
        private readonly PostRepository _repository;
        private readonly UserRepository _userRepository;
        private readonly CategoryRepository _categoryRepository;

        public PostService(
            PostRepository repository,
            UserRepository userRepository,
            CategoryRepository categoryRepository
        )
        {
            _repository = repository;
            _userRepository = userRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<ApiResponse<Post>> AddPost(AddPostRequest request)
        {
            Guid userGUID;
            Guid categoryGUID;
            try
            {
                userGUID = Guid.Parse(request.UserGUID);
                categoryGUID = Guid.Parse(request.CategoryGUID);
            }
            catch (FormatException)
            {
                throw new ApiException(ApiExceptions.POST_INVALID);
            }

            string postText = request.PostText;

            if (
                userGUID == Guid.Empty
                || categoryGUID == Guid.Empty
                || !_utils.validatePostText(postText)
            )
                throw new ApiException(ApiExceptions.POST_INVALID);

            bool userExists = await _userRepository.UserExistsByGUID(userGUID);
            if (!userExists)
                throw new ApiException(ApiExceptions.USER_NOT_FOUND);
            bool categoryExists = await _categoryRepository.CategoryExistsByGUID(categoryGUID);
            if (!categoryExists)
                throw new ApiException(ApiExceptions.CATEGORY_NOT_FOUND);

            Post data = new(userGUID, categoryGUID, postText);
            await _repository.AddPost(data);

            return new ApiResponse<Post>(true, data);
        }
    }
}
