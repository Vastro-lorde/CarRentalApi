using AutoMapper;
using Microsoft.AspNetCore.Identity;
using RentalCarCore.Dtos;
using RentalCarCore.Interfaces;
using RentalCarInfrastructure.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RentalCarCore.Services
{
    public class Authentication : IAuthentication
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly ITokenGen _tokenGen;

        public Authentication(UserManager<User> userManager, IMapper mapper, ITokenGen tokenGen)
        {
            _userManager = userManager;
            _mapper = mapper;
            _tokenGen = tokenGen;
        }

        public Task CreateUser(RegistrationDto userRequest)
        {
            throw new NotImplementedException();
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
                    response.Token =  _tokenGen.GenerateToken(user);
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

        public async Task<UserResponseDto> RegisterAsync(RegistrationDto registrationRequest)
        {
            User user = _mapper.Map<User>(registrationRequest);
            user.UserName = registrationRequest.Email;
            IdentityResult result = await _userManager.CreateAsync(user, registrationRequest.Password);
            if (result.Succeeded)
            {
                var emailToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var response = _mapper.Map<RegistrationDto>(user);
                var answer = new UserResponseDto
                {
                    Id = user.Id,
                    Token = emailToken,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                };
                return answer;
            }
            string errors = result.Errors.Aggregate(string.Empty, (current, error) => current + (error.Description + Environment.NewLine));
            throw new ArgumentException(errors);
        }

    }
}
