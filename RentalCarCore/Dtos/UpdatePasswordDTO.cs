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
        public string NewPassword { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
