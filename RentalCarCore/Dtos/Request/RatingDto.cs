﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarCore.Dtos.Request
{
    public class RatingDto
    {
        public string UserId { get; set; }
        public string CarId { get; set; }
        public int Rating { get; set; }
    }
}
