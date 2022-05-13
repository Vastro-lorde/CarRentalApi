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
            var template = _mailService.GetEmailTemplate("EmailTemplate.html");
            TextInfo textInfo = new CultureInfo("en-GB", false).TextInfo;
            var userName = textInfo.ToTitleCase(user.FirstName);
            var encodedToken = TokenConverter.EncodeToken(user.Token);
            var link = $"{_configuration["Application:AppDomain"]}/Authentication/ResetPassword?email={user.Email}&token={encodedToken}";
            string message = "Reset Password";
            template = template.Replace("{User}", $"{userName}");
            template = template.Replace("{Body}", "Welcome to CarRental Plc,To reset password, click the link below");
            template = template.Replace("{Link}", link);
            template = template.Replace("{Details}", $"If you have trouble clicking on the link above you can paste this link on your browser {link}");
            template = template.Replace("{Action}", $"{message}");
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
