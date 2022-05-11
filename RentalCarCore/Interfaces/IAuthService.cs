using RentalCarCore.Dtos;
using System.Threading.Tasks;

namespace RentalCarCore.Interfaces
{
    public interface IAuthService
    {
        Task<Response<RefreshTokenResponse>> RefreshTokenAsync(RefreshTokenRequestDTO token);
    }
}