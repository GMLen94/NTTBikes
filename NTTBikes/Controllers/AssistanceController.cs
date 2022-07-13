using Microsoft.AspNetCore.Mvc;
using NTTBikes.Data;

namespace NTTBikes.Controllers
{
    public class AssistanceController : Controller
    {
        AppDbContext appDbContext;
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Confirmed(Guid Id)
        {
            appDbContext.Bikes.Find(Id).IsWorking = false;
            //e poi si dovrebbe chiamare l'assistenza per davvero
            return View();
        }
    }
}
