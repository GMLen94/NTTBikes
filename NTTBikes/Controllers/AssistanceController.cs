using Microsoft.AspNetCore.Mvc;
using NTTBikes.Data;
using NTTBikes.Services;

namespace NTTBikes.Controllers
{
    public class AssistanceController : Controller
    {
        BikeServices _bikeService;

        public AssistanceController(BikeServices bikeServices)
        {
            _bikeService = bikeServices;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Confirmed(Guid Id)
        {

            var bike = _bikeService.findBikebyId(Id);
            _bikeService.ChangeStatus(bike);
            //e poi si dovrebbe chiamare l'assistenza per davvero
            return View();
        }
    }
}
