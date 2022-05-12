namespace RentalCarCore.Services
{
    public interface IUserService
    {
        System.Threading.Tasks.Task<UserResponseDto> RegisterAsync(UserRegistrationRequestDTO registrationRequest);
    }
}