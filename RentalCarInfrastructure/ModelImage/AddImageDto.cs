using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace RentalCarInfrastructure.ModelImage
{
    public class AddImageDto
    {
        [Required]
        public IFormFile Image { get; set; }
    }
}