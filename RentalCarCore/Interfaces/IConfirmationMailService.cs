using RentalCarCore.Dtos.Response;
using RentalCarCore.Dtos.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarCore.Interfaces
{
    public interface IConfirmationMailService
    {
        Task SendAConfirmationEmail(UserResponseDto user, string templatefile);
    }
}
