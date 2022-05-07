using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarInfrastructure.Models
{
    public class Blog
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Article { get; set; }
        public string Thumbnail { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
