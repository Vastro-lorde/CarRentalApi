using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarInfrastructure.Models
{
    public class Blog : BaseEntity
    {
        [Required]
        public string UserId { get; set; }

        [StringLength(50, MinimumLength = 3, ErrorMessage = "Part Title must be between 3 and 50 characters in length")]
        public string Title { get; set; }

        public string Article { get; set; }

        [StringLength(50, MinimumLength = 5, ErrorMessage = "Part Thumbnail must be between 5 and 50 characters in length")]
        public string Thumbnail { get; set; }

        public bool IsActive { get; set; }
    }
}
