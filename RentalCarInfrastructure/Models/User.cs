using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarInfrastructure.Models
{
    public class User : IdentityUser
    {
        [StringLength(50, MinimumLength = 2, ErrorMessage ="part FirstName must be between 2 and 50 characters in length")]
        [Required]
        public string FirstName { get; set; }

        [StringLength(50, MinimumLength = 2, ErrorMessage = "part LastName must be between 2 and 50 characters in length")]
        [Required]
        public string LastName { get; set; }
        
        [StringLength(50, MinimumLength = 2, ErrorMessage = "part password must be between 2 and 50 characters in length")]
        [Required]
        public string Password { get; set; }

        [StringLength(125, MinimumLength = 10, ErrorMessage = "part Email must be between 10 and 125 characters in length")]
        [Required]
        override public string Email { get; set; }

        [StringLength(50, MinimumLength = 11, ErrorMessage = "part PhoneNUmber must be between 11 and 50 characters in length")]
        [Required]
        override public string PhoneNumber { get; set; }

        [StringLength(250, MinimumLength = 5, ErrorMessage = "part Address must be between 5 and 250 characters in length")]
        public string Address { get; set; }

        [StringLength(50, MinimumLength = 0, ErrorMessage = "part Gender must be between 0 and 50 characters in length")]
        public string Gender { get; set; }

        [StringLength(250, MinimumLength = 3, ErrorMessage = "part Avatar must be between 3 and 250 characters in length")]
        public string Avatar { get; set; }

        public bool IsActive { get; set; }
        public virtual Dealer Dealers { get; set; }
        public virtual ICollection<Blog> Blogs { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual ICollection<Trip> Trips { get; set; }
    }
}
