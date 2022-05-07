using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarInfrastructure.Models
{
    public class Location
    {
        public Guid Id { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public Guid DealerId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
