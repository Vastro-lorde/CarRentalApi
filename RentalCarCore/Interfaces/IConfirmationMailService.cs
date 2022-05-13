using RentalCarCore.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarCore.Interfaces
{
    public interface IConfirmationMailService
    {
        Task SendAConfirmationEmailForResetPassword(UserResponseDto user);
    }
}
