using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarInfrastructure.Models
{
    public class Location : BaseEntity
    {
        [StringLength(150, MinimumLength = 3, ErrorMessage = "part Address must be between 3 and 150 characters in length")]
        [Required]
        public string Address { get; set; }

        [StringLength(50, MinimumLength = 3, ErrorMessage = "part State must be between 3 and 50 characters in length")]
        [Required]
        public string State { get; set; }

        [StringLength(125, MinimumLength = 3, ErrorMessage = "part Latitude must be between 3 and 50 characters in length")]
        public string Latitude { get; set; }

        [StringLength(125, MinimumLength = 3, ErrorMessage = "part Longitude must be between 3 and 50 characters in length")]
        public string Longitude { get; set; }
         
        [Required]
        public Guid DealerId { get; set; }
    }
}
