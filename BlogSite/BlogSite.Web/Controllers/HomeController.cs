using Autofac;
using Blogsite.Infrastructure.Services;
using BlogSite.Web.Models;
using BlogSite.Web.Models.tourViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace BlogSite.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        protected readonly ILifetimeScope _scope;
        private ITourServices _tourServices;    
        public HomeController(ILogger<HomeController> logger,ILifetimeScope lifetime,ITourServices tour)
        {
            _logger = logger;
            _scope = lifetime;
            _tourServices = tour;   
        }

        public IActionResult Index()
        {

            return View();
        }
        public IActionResult GetListOfDetination()
        {

            //var model = new List<SelectListItem>();

            //foreach (var tour in _tourServices.ListOfTourName())
            //{
            //    var addItem = new SelectListItem()
            //    {
            //        Text = tour.Destination,
            //        Value = tour.Id.ToString(),

            //    };
            //    model.Add(addItem);
            //}
            var model = _tourServices.ListOfTourName();
            var js = model.Select(c => new { c.Id, c.Destination });
            
            return Json(js);
        }
        [HttpGet]
        public IActionResult GetListOfTour()
        {
            var model = _scope.Resolve<TourViewModel>();
            var tour=model.ListOfTours();

            return Json(tour); 
        }
        public IActionResult TourList(string destination)
        {
            var model=_scope.Resolve<TourViewModel>();   
            model.ListofTour(destination);
            return View(model);

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