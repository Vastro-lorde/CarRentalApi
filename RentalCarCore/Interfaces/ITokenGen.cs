using RentalCarCore.Dtos;
using RentalCarInfrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarCore.Interfaces
{
    public interface ITokenGen
    {
        string GenerateToken(User user);
<<<<<<< HEAD
        string GenerateRefreshToken();
=======
<<<<<<< HEAD
        public string GenerateRefreshToken();
=======
        string GenerateRefreshToken(User user);
>>>>>>> reviews
>>>>>>> 9f7bd7411c370e2fcee6076d7a19d140eebbbb92
    }
}
