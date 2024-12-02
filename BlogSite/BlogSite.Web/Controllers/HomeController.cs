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

namespace BlogSite.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        protected readonly ILifetimeScope _scope;
        private ITourServices _tourServices;
        private IHotelServices _hotelServices;

        public HomeController(ILogger<HomeController> logger, ILifetimeScope lifetime, ITourServices tour,
            IHotelServices hotelServices)
        {
            _logger = logger;
            _scope = lifetime;
            _tourServices = tour;
            _hotelServices = hotelServices;
        }

        public IActionResult Index()
        {

            return View();
        }
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
        public IActionResult TourList(string destination)
        {
            if (destination != null)
            {
                try
                {
                    var model = _scope.Resolve<TourViewModel>();
                    model.ListofTour(destination);
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

        //for hotel slot
        [HttpGet]
        public IActionResult GetListOfHotel()
        {
            try
            {
                var model = _scope.Resolve<HotelModelView>();
                var htModel = model.ListOfHotel();

                return Json(htModel);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}");
                ViewBag.Message = "Error";
            }
            return View();
        }
        //  [HttpPost]
        public IActionResult SearchHotel(HotelSearchFilter filter)
        {
            HttpContext.Session.SetString("Location", filter.Location);

            HttpContext.Session.SetString("CheckInDate", filter.CheckInDate.ToString());

            HttpContext.Session.SetString("CheckOutDate", filter.CheckOutDate.ToString());

            HttpContext.Session.SetInt32("NumberOfGuests", filter.NumberOfGuests);

            try
            {
                var model = _scope.Resolve<HotelModelView>();
                model.ListOfHotelWithRoom(filter.Location, filter.CheckInDate, filter.CheckOutDate, filter.NumberOfGuests);
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}");
            }
            return View();
        }
        //[HttpPost]
        public IActionResult SearchHotelRooms(int hotelId)
        {
            // Retrieve parameters from session
            var location = HttpContext.Session.GetString("Location");

            var checkInDate = DateTime.Parse(HttpContext.Session.GetString("CheckInDate"));

            var checkOutDate = DateTime.Parse(HttpContext.Session.GetString("CheckOutDate"));

            var numberOfGuests = HttpContext.Session.GetInt32("NumberOfGuests");

            try
            {
                var model = _scope.Resolve<HotelModelView>();
                model.ListOfHotelWithRoomDetails(hotelId, location, checkInDate, checkOutDate, numberOfGuests ?? 0);
                model.NumberOfGuests = numberOfGuests??0;
                model.night = (checkOutDate - checkInDate).Days; ;
                
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}");
            }
            return View();
        }
        [HttpGet]
        public IActionResult RoomBook(int id)
        {
            var location = HttpContext.Session.GetString("Location");

            var checkInDate = DateTime.Parse(HttpContext.Session.GetString("CheckInDate"));

            var checkOutDate = DateTime.Parse(HttpContext.Session.GetString("CheckOutDate"));

            var numberOfGuests = HttpContext.Session.GetInt32("NumberOfGuests");
            
            var model=_scope.Resolve<RoomDetailsModel>();
            model.RoomDetails(id, checkInDate, checkOutDate, numberOfGuests ?? 0);

            return View(model);  
        }

        [HttpPost]
        public IActionResult RoomBook( RoomDetailsModel model)
        {
            model.ResolveDependency(_scope);
            try
            {
                var checkInDate = HttpContext.Session.GetString("CheckInDate");
                var checkOutDate = HttpContext.Session.GetString("CheckOutDate");
                var numberOfGuests = HttpContext.Session.GetInt32("NumberOfGuests");

                if (checkInDate == null || checkOutDate == null || !numberOfGuests.HasValue)
                {
                    return BadRequest("Session values are missing.");
                }

                // Map session values to the filter
                var filter = new HotelSearchFilter
                {
                    CheckInDate = DateTime.Parse(checkInDate),
                    CheckOutDate = DateTime.Parse(checkOutDate),
                    NumberOfGuests = numberOfGuests.Value
                };
                // Initialize your model and call AddBookingInfo
                //var data = new RoomDetailsModel();
                model.AddBookingInfo(filter);

                return RedirectToAction(nameof(WishPage));
            }
            catch (Exception ex)
            {
                // Log the exception and return an error response
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
        public IActionResult WishPage()
        {
            return View();  
        }
        
        public IActionResult GetHotelList()
        {
            try
            {
                var model = _hotelServices.GetAllHoteslsWithoutLimit();
                return Json(model);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}");
                ViewBag.ErrorMessage = ex.Message;
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