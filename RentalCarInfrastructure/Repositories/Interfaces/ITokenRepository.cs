using RentalCarInfrastructure.Models;
using System.Threading.Tasks;

namespace RentalCarInfrastructure.Repositories.Interfaces
{
    public interface ITokenRepository
    {
        Task<User> GetUserByRefreshToken(string token, string userId);
        Task<bool> UpdateUser(User user);
    }
}