using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarInfrastructure.Models
{
    public class Image : BaseEntity
    {
        public Guid CarId { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        public bool IsFeature { get; set; }
    }
}
