using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarInfrastructure.Models
{
    public class Offer
    {
        public Guid Id { get; set; }
        public Guid CarId { get; set; }
        public string Description { get; set; }
        public double Discount { get; set; }
        public string TypeOfOffer { get; set; }
        public bool IsActive { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
