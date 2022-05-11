using Microsoft.AspNetCore.Mvc;
using RentalCarCore.Dtos;
using RentalCarCore.Interfaces;

namespace RentalCarApi.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IAuthService _authService;
        public AuthenticationController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost]
        public IActionResult RefreshToken(RefreshTokenRequestDTO refresh)
        {
            var result = _authService.RefreshTokenAsync(refresh);
            return Ok(result);
        }
    }
}
