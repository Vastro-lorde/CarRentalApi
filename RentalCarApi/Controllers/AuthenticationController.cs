﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentalCarCore.Dtos;
using RentalCarCore.Interfaces;
using Serilog;
using System;
using System.Threading.Tasks;
namespace RentalCarCore.Controllers
{


    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthentication _authentication;
        public AuthenticationController(IAuthentication authentication)
        {
            _authentication = authentication;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserRequestDto userRequest)
        {
            try
            {
                return Ok(await _authentication.Login(userRequest));
            }
            catch (AccessViolationException)
            {
                return BadRequest();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        [Route("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmailAsync([FromBody] ConfirmEmailRequestDTO confirmEmailRequestDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var result = await _authentication.EmailConfirmationAsync(confirmEmailRequestDTO);
                if (!result.IsSuccessful)
                {
                    return BadRequest(result);
                }
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured we are working on it");
            }
        }

        [HttpPost]
        [Route("RefreshToken")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequestDTO request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var result = await _authentication.RefreshTokenAsync(request);
                if (!result.IsSuccessful)
                {
                    return BadRequest(result);
                }
                return Ok(result);

            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured we are working on it");
            }
        }
    }
}