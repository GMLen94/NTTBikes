using NTTBikes.Models;
using NTTBikes.Data;

namespace NTTBikes.Services
{
    public class BikeServices
    {
        public readonly AppDbContext _appDbContext;
        public BikeServices(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void addBike(Bike bike)
        {
            _appDbContext.Bikes.Add(bike);
            _appDbContext.SaveChanges();
        }
        public List<Bike> getBikes()
        {
            List<Bike> Bikes = _appDbContext.Bikes.ToList();
            return Bikes;
        }
        public Bike findBikebyId(Guid Id)
        {
            return _appDbContext.Bikes.FirstOrDefault(b => b.Id == Id);
        }
        public void PatchLock(Guid Id,bool locks)
        {
            Bike b = findBikebyId(Id);
            b.LockOn = locks;
            _appDbContext.Bikes.Update(b);
            _appDbContext.SaveChanges();
        }
        public void PatchWorking(Guid Id, bool work)
        {
            Bike b = findBikebyId(Id);
            b.IsWorking = work;
            _appDbContext.Bikes.Update(b);
            _appDbContext.SaveChanges();
        }

        public void DeleteBike(Guid Id)
        {
            Bike b=findBikebyId(Id);
            _appDbContext.Bikes.Remove(b);
        }

    }
}
