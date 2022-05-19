using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarCore.Dtos.Response
{
    public class RefreshTokenResponse
    {
        public string NewAccessToken { get; set; }
        public string NewRefreshToken { get; set; }
    }
}
