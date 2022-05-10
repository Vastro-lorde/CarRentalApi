using RentalCarInfrastructure.ModelValidationHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquaWater.Dto.Request
{
    public class UpdatePasswordDTO
    {
        [Required]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = DataAnnotationsHelper.PasswordValidator)]
        public string NewPassword { get; set; }
    }
}
