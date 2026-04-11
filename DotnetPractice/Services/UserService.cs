using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetPractice.Exceptions;
using DotnetPractice.Models;
using DotnetPractice.Models.DTOs;
using DotnetPractice.Models.Requests;
using DotnetPractice.Models.Responses;
using DotnetPractice.Repository;

namespace DotnetPractice.Services
{
    public class UserService
    {
        private readonly UserRepository _repository;

        public UserService(UserRepository repository)
        {
            _repository = repository;
        }

        public async Task<ApiResponse<UserDataDTO>> LoginUser(LoginRequest request)
        {
            string userName = request.UserName;

            User? user = await _repository.GetUserByUserName(userName);
            if (user == null)
            {
                throw new ApiException(ApiExceptions.USER_NOT_FOUND);
            }

            UserDataDTO responseContent = new(user);
            ApiResponse<UserDataDTO> response = new(true, responseContent);

            return response;
        }
    }
}
