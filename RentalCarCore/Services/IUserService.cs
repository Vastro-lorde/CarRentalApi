using RentalCarCore.Dtos;

namespace RentalCarCore.Services
{
    public interface IUserService
    {
        System.Threading.Tasks.Task<UserResponseDto> RegisterAsync(RegistrationDto registrationRequest);
    }
}