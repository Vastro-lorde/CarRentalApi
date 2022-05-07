using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarInfrastructure.Models
{
    public class Image
    {
        public Guid Id { get; set; }
        public Guid CarId { get; set; }
        public string ImageUrl { get; set; }
        public bool IsFeature { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
