using Microsoft.AspNetCore.Mvc;
using NTTBikes.Data;
using NTTBikes.Services;

namespace NTTBikes.Controllers
{
    public class AssistanceController : Controller
    {
        BikeServices bikeService;
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Confirmed(Guid Id)
        {
            bikeService.findBikebyId(Id).IsWorking = false;
            //e poi si dovrebbe chiamare l'assistenza per davvero
            return View();
        }
    }
}
