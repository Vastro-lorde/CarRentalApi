﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarInfrastructure.Models
{
    public class Trip : BaseEntity
    {
        [Required]
        public string CarId { get; set; }

        [Required]
        public string UserId { get; set; }

        [StringLength(50, MinimumLength = 3, ErrorMessage = "Part Status must be between 3 and 50 characters in length")]
        public string Status { get; set; }

        public DateTime PickUpDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public virtual  Transaction  Transactions { get; set; }
    }
}
