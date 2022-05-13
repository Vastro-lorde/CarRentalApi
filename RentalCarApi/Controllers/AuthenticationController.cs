using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentalCarCore.Dtos;
using RentalCarCore.Interfaces;
using Serilog;
using System;
using System.Threading.Tasks;

namespace RentalCarApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        public async Task<ActionResult> CreateUserAsync(RegistrationDto userRequest)
        {
            try
            {
                if (!TryValidateModel(userRequest))
                {
                    return BadRequest();
                }
                await _authentication.CreateUser(userRequest);
                return Ok();
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                return StatusCode(500, "An error occured we are working on it");
            }
        }
    }
}

