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
    }
}
