using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetJwtPractice.Exceptions;
using DotnetJwtPractice.Models;
using DotnetJwtPractice.Models.DTOs;
using DotnetJwtPractice.Models.Requests;
using DotnetJwtPractice.Repository;
using DotnetJwtPractice.Security;
using DotnetJwtPractice.Utils;

namespace DotnetJwtPractice.Services
{
    public class UserService
    {
        private readonly UserUtils _utils = new();
        private readonly SecurityService _securityService;
        private readonly UserRepository _repository;

        public UserService(UserRepository repository, SecurityService securityService)
        {
            _repository = repository;
            _securityService = securityService;
        }

        public async Task<ApiResponse<UserAuthorizationDTO>> RegisterUser(RegisterRequest request)
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

            AuthorizationRole role = newUser.IsAdmin
                ? AuthorizationRole.Admin
                : AuthorizationRole.User;
            string jwt = _securityService.GenerateJwt(newUser.GUID, role);

            UserAuthorizationDTO DTO = new(newUser, jwt);
            ApiResponse<UserAuthorizationDTO> response = new(true, DTO);

            return response;
        }

        public async Task<ApiResponse<UserAuthorizationDTO>> LoginUser(LoginRequest request)
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

            AuthorizationRole role = user.IsAdmin
                ? AuthorizationRole.Admin
                : AuthorizationRole.User;
            string jwt = _securityService.GenerateJwt(user.GUID, role);

            UserAuthorizationDTO DTO = new(user, jwt);
            ApiResponse<UserAuthorizationDTO> response = new(true, DTO);

            return response;
        }
    }
}
