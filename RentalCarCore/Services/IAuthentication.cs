using RentalCarCore.Dtos;
using System.Threading.Tasks;

namespace RentalCarCore.Services
{
    public interface IAuthentication
    {
        Task<UserResponseDto> Login(UserRequestDto userRequestDto);
    }
}