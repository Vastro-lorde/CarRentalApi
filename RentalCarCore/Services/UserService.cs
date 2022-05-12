using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarCore.Services
{
    public class UserService : IUserService
    {
        public async Task<UserResponseDto> RegisterAsync(UserRegistrationRequestDTO registrationRequest)
        {
            User user = _mapper.Map<User>(registrationRequest);
            user.UserName = registrationRequest.Email;
            user.ProfilePictureUrl = "None";
            IdentityResult result = await _userManager.CreateAsync(user, registrationRequest.Password);
            if (result.Succeeded)
            {
                var emailToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var response = _mapper.Map<UserRegistrationRequestDTO>(user);
                var answer = new UserResponseDto
                {
                    Id = user.Id,
                    Token = emailToken,
                    FullName = $"{user.FirstName + " " + user.LastName}",
                    Email = user.Email,
                };
                return answer;
            }
            string errors = result.Errors.Aggregate(string.Empty, (current, error) => current + (error.Description + Environment.NewLine));
            throw new ArgumentException(errors);
        }
    }
}
}
