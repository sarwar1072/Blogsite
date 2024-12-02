using BlogSite.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            var model = new DashboardModel();
            return View(model);
        }
    }
}

