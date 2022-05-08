using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RentalCarInfrastructure.Models
{
    public class Car : BaseEntity
    {
        [Required]
        public string DealerId { get; set; }

        [StringLength(50, MinimumLength = 5, ErrorMessage = "Part Model must be between 5 and 50 characters in length")]
        public string Model { get; set; }


        [StringLength(50, MinimumLength = 4, ErrorMessage = "Part YearOfMan must be between 4 and 50 characters in length")]
        public string YearOfMan { get; set; }


        [StringLength(150, MinimumLength = 10, ErrorMessage = "Part PlateNumber must be between 10 and 150 characters in length")]
        public string PlateNumber { get; set; }


        [StringLength(150, MinimumLength = 10, ErrorMessage = "Part ChasisNumber must be between 10 and 150 characters in length")]
        public string ChasisNumber { get; set; }

        
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Part Color must be between 3 and 50 characters in length")]
        public string Color { get; set; }

        [StringLength(50, MinimumLength = 3, ErrorMessage = "Part TypeOfCar must be between 3 and 50 characters in length")]
        public string TypeOfCar { get; set; }

        public int Mileage { get; set; }
        public double Price { get; set; }

        [StringLength(50, MinimumLength = 3, ErrorMessage = "Part UnitOfPrice must be between 3 and 50 characters in length")]
        public string UnitOfPrice { get; set; }

        public bool IsVerify { get; set; }
        public virtual CarDetail CarDetail { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Offer> Offers { get; set; }
        public virtual ICollection<Trip> Trips { get; set; }
        public virtual ICollection<Image> Images { get; set; }
    }
}
