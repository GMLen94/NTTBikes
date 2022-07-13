using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NTTBikes.Models;
using NTTBikes.Services;

namespace NTTBikes.Controllers
{
    public class BikeController : Controller
    {
        private readonly BikeServices _bikeservice;
        private readonly StationService _stationService;
        public BikeController(BikeServices bikeServices, StationService stationService)
        {
            _bikeservice = bikeServices;
            _stationService = stationService;
        }
        public IActionResult Index()
        {
            List<Bike> bikes= _bikeservice.getBikes();

            return View(bikes);
        }
        
        [Authorize (Roles ="Admin")]
        public IActionResult CreateBike()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public IActionResult CreatedBike(IFormCollection bikeform)
        {
            Bike bike = new Bike()
            {
                Id = Guid.NewGuid(),
                Type = bikeform["Type"],
                IsWorking = bool.Parse(bikeform["IsWorking"]),
                LockOn = bool.Parse(bikeform["LockOn"]),
                IdStation = new Guid("d70552c0-6185-4c78-88c0-f56272678bc9"),
                Station=_stationService.getStationbyId(new Guid("d70552c0-6185-4c78-88c0-f56272678bc9"))
            };
            _bikeservice.addBike(bike);
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Admin")]
        public IActionResult DeletedBike(Guid id)
        {
            _bikeservice.DeleteBike(id);
            return RedirectToAction("Index");
        }
    }
}
