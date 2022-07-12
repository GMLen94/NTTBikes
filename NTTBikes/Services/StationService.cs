using NTTBikes.Models;
using NTTBikes.Data;

namespace NTTBikes.Services
{
    public class StationService
    {
        public readonly AppDbContext _appDbContext;
        public StationService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public void addStation(BikeStation station)
        {
            _appDbContext.BikeStations.Add(station);
            _appDbContext.SaveChanges();
        }
        public List<BikeStation> getStations()
        {
            List<BikeStation> Stations = _appDbContext.BikeStations.ToList();
            return Stations;
        }
        public BikeStation getStationbyId(Guid Id)
        {
            return _appDbContext.BikeStations.FirstOrDefault(s=>s.Id==Id);
        }
        public void addBiketoStation(Guid station_id, Bike bike)
        {
            BikeStation station=getStationbyId(station_id);
            station.Bikes.Add(bike);
            _appDbContext.Update(station);
            _appDbContext.SaveChanges();
        }
        public void deleteStation(Guid Id)
        {
            _appDbContext.BikeStations.Remove(getStationbyId(Id));
        }
    }
}
