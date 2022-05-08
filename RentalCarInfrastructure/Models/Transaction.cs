using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarInfrastructure.Models
{
    public class Transaction : BaseEntity
    {
        [Required]
        public string TripId { get; set; }
        public double Amount { get; set; }

        [StringLength(125, MinimumLength = 5, ErrorMessage = "Part PaymentMethod must be between 5 and 125 characters in length")]
        public string PaymentMethod { get; set; }

        [StringLength(125, MinimumLength = 5, ErrorMessage = "Part TransactionRef must be between 5 and 125 characters in length")]
        public string TransactionRef { get; set; }

        [StringLength(50, MinimumLength = 4, ErrorMessage = "Part Status must be between 4 and 50 characters in length")]
        public string Status { get; set; }

        public virtual Trip Trips { get; set; }
    }
}
