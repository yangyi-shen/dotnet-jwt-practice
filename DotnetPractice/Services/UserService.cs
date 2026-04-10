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

        public async Task<ApiResponse<LoginResponseDTO>> LoginUser(LoginRequest request)
        {
            string password = request.Password;

            User? user = await _repository.GetUserByPassword(password);
            if (user == null)
            {
                throw new DotnetPracticeException(DotnetPracticeExceptionCodes.USER_NOT_FOUND);
            }

            LoginResponseDTO responseContent = new(user);
            ApiResponse<LoginResponseDTO> response = new(responseContent);

            return response;
        }
    }
}
