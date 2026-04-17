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

        private enum GetFilteredPostsParam
        {
            USER,
            CATEGORY,
        }

        public async Task<ApiResponse<List<Post>>> GetFilteredPosts(GetFilteredPostsRequest request)
        {
            Guid? userGUID = await validateAndParseGUID(
                request.UserGUID,
                GetFilteredPostsParam.USER
            );
            Guid? categoryGUID = await validateAndParseGUID(
                request.CategoryGUID,
                GetFilteredPostsParam.CATEGORY
            );

            List<Post> data = await _repository.GetFilteredPosts(userGUID, categoryGUID);
            return new ApiResponse<List<Post>>(true, data);
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

        private async Task<Guid?> validateAndParseGUID(string? rawGUID, GetFilteredPostsParam param)
        {
            Guid? GUID = null;

            if (!string.IsNullOrEmpty(rawGUID))
            {
                try
                {
                    GUID = Guid.Parse(rawGUID);
                }
                catch (FormatException)
                {
                    throw new ApiException(ApiExceptions.PARAMETERS_INVALID);
                }

                if (param == GetFilteredPostsParam.USER)
                {
                    bool userExists = await _userRepository.UserExistsByGUID(GUID.Value);
                    if (!userExists)
                        throw new ApiException(ApiExceptions.USER_NOT_FOUND);
                }
                else if (param == GetFilteredPostsParam.CATEGORY)
                {
                    bool categoryExists = await _categoryRepository.CategoryExistsByGUID(
                        GUID.Value
                    );
                    if (!categoryExists)
                        throw new ApiException(ApiExceptions.CATEGORY_NOT_FOUND);
                }
            }
            return GUID;
        }
    }
}
