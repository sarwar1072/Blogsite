using Autofac;
using BlogSite.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "User, Admin")]

    public class DashboardController : Controller
    {
        protected readonly ILifetimeScope _scope;

        public DashboardController(ILifetimeScope scope)
        {
                _scope = scope;
        }
        public IActionResult Index()
        {
            var model =_scope.Resolve<DashboardModel>();
            model.GetAllProperty();

            return View(model);
        }
    }
}

