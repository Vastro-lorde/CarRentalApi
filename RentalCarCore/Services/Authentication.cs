using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using RentalCarCore.Dtos;
using RentalCarCore.Interfaces;
using RentalCarCore.Utilities;
using RentalCarInfrastructure.Models;
using RentalCarInfrastructure.Repositories.Interfaces;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace RentalCarCore.Services
{
    public class Authentication : IAuthentication
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly ITokenGen _tokenGen;
        private readonly ITokenRepository _tokenRepository;
        private readonly IConfirmationMailService _confirmationMailService;

        public Authentication(ITokenRepository tokenRepository, ITokenGen tokenGen, UserManager<User> userManager, IMapper mapper, IConfirmationMailService confirmationMailService)
        {
            _mapper = mapper;
            _tokenRepository = tokenRepository;
            _tokenGen = tokenGen;
            _userManager = userManager;
            _confirmationMailService = confirmationMailService; 
        }

        public async Task<Response<UserResponseDto>> Login(UserRequestDto userRequestDto)
        {
            User user = await _userManager.FindByEmailAsync(userRequestDto.Email);
            if (user.GetType().GetProperties().All(x => x.GetValue(user) == null))
            {
                throw new Exception("");
            }
            if (user != null)
            {
                if (await _userManager.CheckPasswordAsync(user, userRequestDto.Password))
                {
                    var response = _mapper.Map<UserResponseDto>(user);
                    response.Token = _tokenGen.GenerateToken(user);
                    user.RefreshToken = _tokenGen.GenerateRefreshToken();
                    user.ExpiryTime = DateTime.Now.AddDays(3);
                    return new Response<UserResponseDto>
                    {
                        Data = response,
                        Message = MessageResponse.SuccessMessage,
                        ResponseCode = System.Net.HttpStatusCode.OK,
                        IsSuccessful = true
                    };
                }
                return new Response<UserResponseDto>
                {
                    Message = MessageResponse.FailedMessage,
                    ResponseCode = System.Net.HttpStatusCode.BadRequest,
                    IsSuccessful = false,
                };
            }
            throw new AccessViolationException("Invalid Credentails");
        }

        public async Task<Response<RefreshTokenResponse>> RefreshTokenAsync(RefreshTokenRequestDTO token)
        {
            var response = new Response<RefreshTokenResponse>();
            var refreshToken = token.RefreshToken;
            var userId = token.UserId;

            var user = await _tokenRepository.GetUserByRefreshToken(refreshToken, userId);
            if (user.RefreshToken != refreshToken || user.ExpiryTime != DateTime.Now)
            {
                response.Data = null;
                response.ResponseCode = HttpStatusCode.BadRequest;
                response.Message = "Bad Request";
                response.IsSuccessful = false;
                return response;
            }
            var refreshMapping = new RefreshTokenResponse
            {
                NewAccessToken = _tokenGen.GenerateToken(user),
                NewRefreshToken = _tokenGen.GenerateRefreshToken()
            };

            user.RefreshToken = refreshMapping.NewRefreshToken;
            await _tokenRepository.UpdateUser(user);
            response.Data = refreshMapping;
            response.ResponseCode = HttpStatusCode.OK;
            response.Message = "Token Refresh Successfully";
            response.IsSuccessful = true;
            return response;
        }

        public async Task<Response<string>> EmailConfirmationAsync(ConfirmEmailRequestDTO confirmEmailRequest)
        {
            var user = await _userManager.FindByEmailAsync(confirmEmailRequest.Email);
            if (user != null)
            {
                var decodedToken = TokenConverter.DecodeToken(confirmEmailRequest.Token);
                var result = await _userManager.ConfirmEmailAsync(user, decodedToken);

                if (result.Succeeded)
                {
                    var response = new Response<string>()
                    {
                        Message = "Email Confirmation was successful",
                        IsSuccessful = true
                    };

                    return response;
                }
                throw new ArgumentException("Your email could not be confirmed");
            }
            throw new ArgumentException($"User with email '{confirmEmailRequest.Email}' not found");
        }
        public async Task<Response<string>> UpdatePasswordAsync(UpdatePasswordDTO updatePasswordDto)
        {
            var user = await _userManager.FindByIdAsync(updatePasswordDto.Id);
            var comparePassword = await _userManager.CheckPasswordAsync(user, updatePasswordDto.CurrentPassword);
            if (comparePassword)
            {
                var result = await _userManager.ChangePasswordAsync(user, updatePasswordDto.CurrentPassword, updatePasswordDto.NewPassword);
                if (result.Succeeded)
                {
                    return new Response<string>()
                    {
                        IsSuccessful = true,
                        Message = "Password updated"
                    };

                }
                return new Response<string>()
                {
                    IsSuccessful = false,
                    ResponseCode = System.Net.HttpStatusCode.BadRequest,
                    Message = "password failed, please try again."
                };
            }

            return new Response<string>()
            {
                Message = "Current password is not correct",
                ResponseCode = System.Net.HttpStatusCode.BadRequest,
                IsSuccessful = false
            };
        }

        public async Task<Response<string>> ResetPasswordAsync(ResetPasswordDto resetPassword)
        {
            var user = await _userManager.FindByEmailAsync(resetPassword.Email);
            if (user == null)
            {
                new Response<string>
                {
                    IsSuccessful = false,
                    Message = $"Email {resetPassword.Email} does not exist"
                };
            }
            var token = TokenConverter.DecodeToken(resetPassword.Token);
            var result = await _userManager.ResetPasswordAsync(user, token, resetPassword.NewPassword);
            if (result.Succeeded)
            {
                return new Response<string>
                {
                    IsSuccessful = true,
                    Message = "Password has been reset successfully"
                };
            }
            return new Response<string>
            {
                IsSuccessful = false,
                Message = " Password was not reset successfully",
                //Errors = result.GetIdentityErrors()
            };
        }
        public async Task<Response<string>> ForgotPasswordResetAsync(ForgotPasswordDto forgotPasswordDto)
        {
            var user = await _userManager.FindByEmailAsync(forgotPasswordDto.Email);
            var userResponse = _mapper.Map<UserResponseDto>(user);
            var response = new Response<string>
            {
                IsSuccessful = false,
                Message = "A mail has been sent to the specified email address if it exists"
            };
            if (user == null)
            {
                response.IsSuccessful = false;
                return response;
            }
            userResponse.FirstName = user.FirstName;
            userResponse.LastName = user.LastName;
            userResponse.Token = await _userManager.GeneratePasswordResetTokenAsync(user);
            await _confirmationMailService.SendAConfirmationEmailForResetPassword(userResponse);
            response.IsSuccessful = true;
            return response;
        }

    }
}
