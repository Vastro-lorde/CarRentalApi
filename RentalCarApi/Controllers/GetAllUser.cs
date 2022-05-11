using System.ComponentModel.DataAnnotations;

namespace RentalCarApi.Controllers
{
    public class GetAllUser
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string SecondName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}