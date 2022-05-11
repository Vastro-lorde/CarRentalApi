using AutoMapper;
using RentalCarCore.Dtos;
using RentalCarCore.Interfaces;
using RentalCarInfrastructure.Models;
using RentalCarInfrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarCore.Services
{
    public class AuthService : IAuthService
    {
        private readonly ITokenRepository _tokenRepository;
        private readonly ITokenGen _tokenGen;
        public AuthService(ITokenRepository tokenRepository, ITokenGen tokenGen)
        {
            _tokenRepository = tokenRepository;
            _tokenGen = tokenGen;
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
    }
}
