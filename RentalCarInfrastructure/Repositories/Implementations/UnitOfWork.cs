using RentalCarInfrastructure.Context;
using RentalCarInfrastructure.Interfaces;
using RentalCarInfrastructure.Models;
using RentalCarInfrastructure.Repositories.Implementations;
using RentalCarInfrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarInfrastructure.Repositories.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;
        public IGenericRepository<User> UserRepository =>  new GenericRepository<User>(_appDbContext);

        public IGenericRepository<Car> CarRepository => new GenericRepository<Car>(_appDbContext);

        public IGenericRepository<CarDetail> CarDetailRepository => new GenericRepository<CarDetail>(_appDbContext);

        public IGenericRepository<Blog> BlogRepository => new GenericRepository<Blog>(_appDbContext);

        public IGenericRepository<Comment> CommentRepository => new GenericRepository<Comment>(_appDbContext);

        public IGenericRepository<Dealer> DealerRepository => new GenericRepository<Dealer>(_appDbContext);

        public IGenericRepository<Image> ImageRepository => new GenericRepository<Image>(_appDbContext);

        public IGenericRepository<Location> LocationRepository => new GenericRepository<Location>(_appDbContext);

        public IGenericRepository<Trip> TripRepository => new GenericRepository<Trip>(_appDbContext);

        public IGenericRepository<Offer> OfferRepository => new GenericRepository<Offer>(_appDbContext);

        public IGenericRepository<Rating> RatingRepository => new GenericRepository<Rating>(_appDbContext);

        public IGenericRepository<Transaction> TransactionRepository => new GenericRepository<Transaction>(_appDbContext);

        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public AppDbContext AppDatabaseContext()
        {
            return _appDbContext;
        }

        public async Task Save()
        {
            await _appDbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _appDbContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
