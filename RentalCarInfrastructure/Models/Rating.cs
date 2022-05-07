using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarInfrastructure.Models
{
    public class Rating : BaseEntity
    {
        public Guid carId { get; set; }
        public int Ratings { get; set; }
        public Guid UserId { get; set; }
    }
}
