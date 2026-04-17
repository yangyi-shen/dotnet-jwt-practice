using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetJwtPractice.Exceptions;
using DotnetJwtPractice.Models;
using DotnetJwtPractice.Models.DTOs;
using DotnetJwtPractice.Models.Requests;
using DotnetJwtPractice.Repository;
using DotnetJwtPractice.Utils;

namespace DotnetJwtPractice.Services
{
    public class UserService
    {
        private readonly UserUtils _utils = new();
        private readonly UserRepository _repository;

        public UserService(UserRepository repository)
        {
            _repository = repository;
        }

        public async Task<ApiResponse<User>> RegisterUser(RegisterRequest request)
        {
            string userName = request.UserName;
            if (!_utils.ValidateUserName(userName))
            {
                throw new ApiException(ApiExceptions.USER_INVALID);
            }

            User? existingUser = await _repository.GetUserByUserName(userName);
            if (existingUser != null)
            {
                throw new ApiException(ApiExceptions.USER_ALREADY_EXISTS);
            }

            User newUser = new(userName);
            await _repository.AddUser(newUser);

            ApiResponse<User> response = new(true, newUser);

            return response;
        }

        public async Task<ApiResponse<User>> LoginUser(LoginRequest request)
        {
            string userName = request.UserName;

            if (!_utils.ValidateUserName(userName))
            {
                throw new ApiException(ApiExceptions.USER_INVALID);
            }

            User? user = await _repository.GetUserByUserName(userName);
            if (user == null)
            {
                throw new ApiException(ApiExceptions.USER_NOT_FOUND);
            }

            ApiResponse<User> response = new(true, user);

            return response;
        }
    }
}
