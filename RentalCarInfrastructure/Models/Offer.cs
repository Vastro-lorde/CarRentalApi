using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarInfrastructure.Models
{
    public class Offer : BaseEntity
    {
        public Guid CarId { get; set; }
        public string Description { get; set; }
        public double Discount { get; set; }
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Part TypeOfOffer must be between 3 and 50 characters in length")]
        public string TypeOfOffer { get; set; }
        public bool IsActive { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
