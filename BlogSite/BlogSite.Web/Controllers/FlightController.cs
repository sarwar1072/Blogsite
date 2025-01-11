using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Web.Controllers
{
    public class FlightController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
