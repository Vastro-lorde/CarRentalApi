using Microsoft.Extensions.Configuration;
using RentalCarCore.Dtos;
using RentalCarCore.Interfaces;
using RentalCarCore.Utilities;
using RentalCarInfrastructure.ModelMail;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarCore.Services
{
    public class ConfirmationMailService : IConfirmationMailService
    {
        private readonly IMailService _mailService;
        private readonly IConfiguration _configuration;
        public ConfirmationMailService(IMailService mailService, IConfiguration configuration)
        {
            _mailService = mailService;
            _configuration = configuration;
        }
        public async Task SendAConfirmationEmailForResetPassword(UserResponseDto user)
        {
            var template = _mailService.GetEmailTemplate("ForgotPassword.html");
            TextInfo textInfo = new CultureInfo("en-GB", false).TextInfo;
            var userName = textInfo.ToTitleCase(user.FirstName);
            var encodedToken = TokenConverter.EncodeToken(user.Token);
            var link = $"{_configuration["Application:AppDomain"]}/Authentication/ResetPassword?email={user.Email}&token={encodedToken}";
           
            template = template.Replace("{User}", $"{userName}");
            template = template.Replace("{link}", link);
            
            var mailRequest = new MailRequest
            {
                ToEmail = user.Email,
                Body = template,
                Subject = "Reset Password"
            };
            await _mailService.SendEmailAsync(mailRequest);
        }
    }

}
