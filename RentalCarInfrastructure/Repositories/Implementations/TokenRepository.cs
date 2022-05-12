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
        private readonly IGenericRepository<User> _genericRepository;
        public TokenRepository(IGenericRepository<User> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<User> GetUserByRefreshToken(string token, string userId)
        {
            var user = await _genericRepository.GetARecord(userId);

            if (user == null)
            {
                throw new ArgumentException("user does not exist");
            }
            return user;
        }
        public async Task<bool> UpdateUser(User user)
        {
            return await _genericRepository.Update(user);
        }
    }
}
