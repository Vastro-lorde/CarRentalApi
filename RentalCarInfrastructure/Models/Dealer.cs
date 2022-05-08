using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarInfrastructure.Models
{
    public class Dealer : BaseEntity
    {
        [Required]
        public string UserId { get; set; }

        [StringLength(150, MinimumLength = 3, ErrorMessage = "part CompanyName must be between 3 and 150 characters in length")]
        public string CompanyName { get; set; }

        [StringLength(50, MinimumLength = 3, ErrorMessage = "part Type must be between 3 and 50 characters in length")]
        public string Type { get; set; }

        [StringLength(125, MinimumLength = 3, ErrorMessage = "part BusinessEmail must be between 3 and 125 characters in length")]
        public string BusinessEmail { get; set; }

        [StringLength(50, MinimumLength = 11, ErrorMessage = "part BusinessPhoneNumber must be between 11 and 50 characters in length")]
        public string BusinessPhoneNumber { get; set; }

        public bool IsActivated { get; set; }


        [StringLength(50, MinimumLength = 4, ErrorMessage = "part IdentityNumber must be between 4 and 50 characters in length")]
        public string IdentityNumber { get; set; }

        [StringLength(50, MinimumLength = 4, ErrorMessage = "part SocialMedia must be between 4 and 50 characters in length")]
        public string SociallMedia { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
        public virtual ICollection<Location> Locations { get; set; }
    }
}
