using Autofac;
using Autofac.Core.Lifetime;
using Blogsite.Infrastructure.Entities;
using Blogsite.Infrastructure.Services;
using BlogSite.Web.Models;
using BlogSite.Web.Models.HotelViewM;
using BlogSite.Web.Models.tourViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Host.Mef;
using System.Diagnostics;
using System.Reflection.Metadata;

namespace BlogSite.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        protected readonly ILifetimeScope _scope;
        private ITourServices _tourServices;

        public HomeController(ILogger<HomeController> logger, ILifetimeScope lifetime, ITourServices tour)
        {
            _logger = logger;
            _scope = lifetime;
            _tourServices = tour;
        }

        public IActionResult Index()
        {
            var model=_scope.Resolve<TourViewModel>();
            model.PopularTourDestination();
            model.ListOfTours();

            return View(model);
        }
        //public IActionResult ListOfTourDestination(string Destination)
        //{
        //    var model = _scope.Resolve<TourViewModel>();

        //}
        public IActionResult GetListOfDetination()
        {          
            try
            {
                var model = _tourServices.ListOfTourName();
                var js = model.Select(c => new { c.Id, c.Destination });

                return Json(js);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}");
                ViewBag.ErrorMessage = ex.Message;
            }
            return View();
        }
        public IActionResult Details(int id)
        {
            try
            {
                var model = _scope.Resolve<TourDetailsModel>();
                model.ResolveDependency(_scope);

                model.GetTourDetails(id);
                //_logger.LogInformation("Returning TourList view with model data");
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}");
                ViewBag.Message = "Error";
            }
            return View();
        }
        [HttpPost]
        public IActionResult Details([FromBody] TourDetailsModel model)
        {
            try
            {
                model.ResolveDependency(_scope);
                //await model.GetUserInfoAsync();
                model.AddConsult();
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}");
                ViewBag.Message = "Error";
            }

            return View();
        }
        public IActionResult TourList(string Destination)
        {
            if (Destination != null)
            {
                try
                {
                    var model = _scope.Resolve<TourViewModel>();
                    model.ListofTour(Destination);
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
        public IActionResult ResultNotFound()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetListOfTour()
        {
            try
            {
                var model = _scope.Resolve<TourViewModel>();
                var tour = model.ListOfTours();

                return Json(tour);
            }
            catch (Exception ex) {
                _logger.LogError($"{ex.Message}");
                ViewBag.Message = "Error";

            }
            return View();
        }   

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}