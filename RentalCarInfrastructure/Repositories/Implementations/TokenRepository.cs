using RentalCarInfrastructure.Interfaces;
using RentalCarInfrastructure.Models;
using RentalCarInfrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarInfrastructure.Repositories.Implementations
{
    public class TokenRepository : ITokenRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public TokenRepository( IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<User> GetUserByRefreshToken(string token, string userId)
        {
            var user = await _unitOfWork.UserRepository.GetARecord(userId);

            if (user == null)
            {
                throw new ArgumentException("user does not exist");
            }
            return user;
        }
        public async Task<bool> UpdateUser(User user)
        {
            return await _unitOfWork.UserRepository.Update(user);
        }
    }
}
