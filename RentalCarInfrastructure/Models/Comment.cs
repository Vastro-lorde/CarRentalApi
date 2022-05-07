using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarInfrastructure.Models
{
    public class Comment : BaseEntity
    {
        public Guid CarId { get; set; }
        public string Comments { get; set; }
        public Guid Userid { get; set; }
    }
}
