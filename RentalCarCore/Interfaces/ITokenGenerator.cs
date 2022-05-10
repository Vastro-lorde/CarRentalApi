using RentalCarInfrastructure.Models;
using System.Threading.Tasks;

namespace RentalCarCore.Interfaces
{
    public interface ITokenGenerator
    {
        Task<string> GenerateToken(User user);
    }
}