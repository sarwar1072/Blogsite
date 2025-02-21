using Autofac;
using Blogsite.Infrastructure.Services;
using BlogSite.Web.Models.tourViewModel;
using BlogSite.Web.Models.VisaViewModelFolder;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Web.Controllers
{
    public class VisaController : Controller
    {
        private readonly ILogger<VisaController> _logger;
        protected readonly ILifetimeScope _scope;
        private IVisaServices _visaServices;
        public VisaController(ILogger<VisaController> logger, ILifetimeScope lifetime, IVisaServices visaServices)
        {
            _logger = logger;
            _scope = lifetime;
            _visaServices = visaServices;

        }
        public IActionResult Index()
        {
            var model = _scope.Resolve<VisaViewModel>();
            return View(model);
        }
        public IActionResult GetDropDownList()
        {
            try
            {
                var model = _visaServices.GetOnlyVisaDestinationName();
                return Json(model);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}");
                ViewBag.ErrorMessage = ex.Message;
            }
            return View();
        }
        public IActionResult VisaList(string Destination)
        {
            if (Destination != null)
            {
                try
                {
                    var model = _scope.Resolve<VisaViewModel>();
                    model.ListofVisa(Destination);
                    return View(model);
                }
                catch (Exception e)
                {
                    _logger.LogError($"{e.Message}");
                    ViewBag.Message = "Error";
                }
            }
            else
            {
                return RedirectToAction("ResultNotFound");
            }
            return View();
        }

    }
}
