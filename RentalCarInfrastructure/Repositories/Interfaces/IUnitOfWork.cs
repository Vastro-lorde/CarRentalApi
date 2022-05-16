using RentalCarInfrastructure.Context;
using RentalCarInfrastructure.Models;
using RentalCarInfrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarInfrastructure.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<User> UserRepository { get; }
        IGenericRepository<Car> CarRepository { get; }
        IGenericRepository<CarDetail> CarDetailRepository { get; }
        IGenericRepository<Blog> BlogRepository { get; }
        IGenericRepository<Comment> CommentRepository { get; }
        IGenericRepository<Dealer> DealerRepository { get; }
        IGenericRepository<Image> ImageRepository { get; }
        IGenericRepository<Location> LocationRepository { get; }
        IGenericRepository<Trip> TripRepository { get; }
        IGenericRepository<Offer> OfferRepository { get; }
        IGenericRepository<Rating> RatingRepository { get; }
        IGenericRepository<Transaction> TransactionRepository { get; }
        AppDbContext AppDatabaseContext();
        Task Save();
        void Dispose();
    }
}
