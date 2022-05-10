using AutoMapper;
using Microsoft.AspNetCore.Identity;
using RentalCarCore.Dtos;
using RentalCarCore.Interfaces;
using RentalCarInfrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarCore.Services
{
    public class Authentication : IAuthentication
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly ITokenGenerator _tokenGenerator;

        public Authentication(UserManager<User> userManager, IMapper mapper, ITokenGenerator tokenGenerator)
        {
            _userManager = userManager;
            _mapper = mapper;
            _tokenGenerator = tokenGenerator;
        }
        public async Task<UserResponseDto> Login(UserRequestDto userRequestDto)
        {
            User user = await _userManager.FindByEmailAsync(userRequestDto.Email);
            if (user != null)
            {
                if (await _userManager.CheckPasswordAsync(user, userRequestDto.Password))
                {
                    var response = _mapper.Map<UserResponseDto>(user);
                    response.Token = await _tokenGenerator.GenerateToken(user);
                    return response;
                }
                throw new AccessViolationException("Invalid Details");
            }
            throw new AccessViolationException("Invalid Credentails");
        }
    }
}
