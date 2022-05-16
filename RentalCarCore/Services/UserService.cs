using AutoMapper;
using Microsoft.AspNetCore.Identity;
using RentalCarCore.Dtos.Response;
using RentalCarCore.Dtos.Request;
using RentalCarCore.Interfaces;
using RentalCarInfrastructure.Models;
using RentalCarInfrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using RentalCarInfrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace RentalCarCore.Services
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<User> _genericRepository;
        private readonly IMapper _mapper;
        private readonly AppDbContext _appDbContext;
        private readonly UserManager<User> _userManager;
        public UserService(IGenericRepository<User> genericRepository, IMapper mapper, AppDbContext appDbContext, UserManager<User> userManager)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
            _appDbContext = appDbContext;
            _userManager = userManager;
        }

        public async Task<Response<List<TripsDTO>>> GetTrips(string UserId)
        {
            var user = await _genericRepository.GetARecord(UserId);

            if (user != null)
            {
                var trips = _appDbContext.Trips.Where(x => x.UserId == user.Id).ToList();
                var result = _mapper.Map<List<TripsDTO>>(trips);
                return new Response<List<TripsDTO>>()
                {
                    Data = result,
                    IsSuccessful = true,
                    Message = "Response Successful",
                    ResponseCode = HttpStatusCode.OK
                };
            }

            return new Response<List<TripsDTO>>()
            {
                Data = null,
                IsSuccessful = false,
                Message = "Response UnSuccessful",
                ResponseCode = HttpStatusCode.BadRequest
            };
        }

        public async Task<Response<string>> UpdateUserDetails(string Id, UpdateUserDto updateUserDto)
        {

            var user = await _userManager.FindByIdAsync(Id);

            if (user != null)
            {
                user.FirstName = string.IsNullOrWhiteSpace(updateUserDto.FirstName) ? user.FirstName : updateUserDto.FirstName;
                user.LastName = string.IsNullOrWhiteSpace(updateUserDto.LastName) ? user.LastName : updateUserDto.LastName;
                user.PhoneNumber = string.IsNullOrWhiteSpace(updateUserDto.PhoneNumber) ? user.PhoneNumber : updateUserDto.PhoneNumber;
                user.Address = string.IsNullOrWhiteSpace(updateUserDto.Address) ? user.Address : updateUserDto.Address;

                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return new Response<string>()
                    {
                        IsSuccessful = true,
                        Message = "Profile updated"
                    };
                }
                return new Response<string>()
                {
                    IsSuccessful = false,
                    Message = "Profile not updated"
                };
            }

            throw new ArgumentException("User not found");
        }
    }
}
