﻿using AutoMapper;
using RentalCarCore.Dtos.Response;
using RentalCarCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using RentalCarInfrastructure.Interfaces;
using RentalCarInfrastructure.Models;
using RentalCarCore.Dtos.Request;
using RentalCarInfrastructure.Repositories.Interfaces;
using System.Linq;

namespace RentalCarCore.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Rating> _ratingRepository;
        
        public UserService(IMapper mapper, IUnitOfWork unitOfWork, IGenericRepository<Rating> ratingRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _ratingRepository = ratingRepository;
            
        }

        public async Task<Response<List<TripsDTO>>> GetTrips(string UserId)
        {
            var user = await _unitOfWork.UserRepository.GetUser(UserId);

            if (user != null)
            {
                var trips = await _unitOfWork.UserRepository.GetTripsByUserId(UserId);
                if (trips != null)
                {
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
                    Message = "Response Successful",
                    ResponseCode = HttpStatusCode.BadRequest
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
            var user = _unitOfWork.UserRepository.GetUser(Id);

            if (user != null)
            {

                var result = await _unitOfWork.UserRepository.UpdateUser(new User()
                {
                    FirstName = string.IsNullOrWhiteSpace(updateUserDto.FirstName) ? updateUserDto.FirstName : updateUserDto.FirstName,
                    LastName = string.IsNullOrWhiteSpace(updateUserDto.LastName) ? updateUserDto.LastName : updateUserDto.LastName,
                    Address = string.IsNullOrWhiteSpace(updateUserDto.PhoneNumber) ? updateUserDto.PhoneNumber : updateUserDto.PhoneNumber,
                    PhoneNumber = string.IsNullOrWhiteSpace(updateUserDto.Address) ? updateUserDto.Address : updateUserDto.Address,

                });

                if (result)
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

        public async Task<Response<string>> AddRating(RatingDto ratingDto)
        {
            var user = await _unitOfWork.UserRepository.GetUser(ratingDto.UserId);
            var trips = await _unitOfWork.UserRepository.GetTripsByUserId(ratingDto.UserId);
            var trip = trips.FirstOrDefault(x => x.CarId == ratingDto.CarId);

            if (user != null)
            {
                if(trip != null)
                {
                    var rate = _mapper.Map<Rating>(ratingDto);
                    var result = await _ratingRepository.Add(rate);
                    if (result)
                    {
                        return new Response<string>
                        {
                            IsSuccessful = true,
                            Message = "Response Successfull",
                            ResponseCode = HttpStatusCode.OK
                        };
                    }
                }
                return new Response<string>
                {
                    IsSuccessful = false,
                    Message = "Trip not completed",
                    ResponseCode = HttpStatusCode.BadRequest
                };

            }

            return new Response<string>
            {
                IsSuccessful = false,
                Message = "Response NotSuccessful",
                ResponseCode = HttpStatusCode.BadRequest
            };
        }

        public async Task<Response<string>> AddComment(CommentDto commentDto)
        {
            var user = await _unitOfWork.UserRepository.GetUser(commentDto.UserId);
            var trips = await _unitOfWork.UserRepository.GetTripsByUserId(commentDto.UserId);
            var trip = trips.FirstOrDefault(x => x.CarId == commentDto.CarId);
            if (user != null )
            {
                if(trip != null)
                {
                    var comment = _mapper.Map<Comment>(commentDto);
                    var result = await _unitOfWork.CommentRepository.AddComment(comment);
                    if (result)
                    {
                        return new Response<string>
                        {
                            IsSuccessful = true,
                            Message = "Comment Added Successfully",
                            ResponseCode = HttpStatusCode.OK
                        };
                    }
                }
                return new Response<string>
                {
                    IsSuccessful = false,
                    Message = "Trip not Completed",
                    ResponseCode = HttpStatusCode.BadRequest
                };

            }
            return new Response<string>
            {
                IsSuccessful = false,
                Message = "Comment Not Successfull",
                ResponseCode = HttpStatusCode.BadRequest
            };

        }
    }
}
