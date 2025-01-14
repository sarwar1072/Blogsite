using Autofac;
using Blogsite.Infrastructure.Services;
using BlogSite.Web.Models.HotelViewM;
using Microsoft.AspNetCore.Mvc;
using static System.Formats.Asn1.AsnWriter;

namespace BlogSite.Web.Controllers
{
    public class HotelController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        protected readonly ILifetimeScope _scope;
        private IHotelServices _hotelServices;
        public HotelController(ILogger<HomeController> logger, ILifetimeScope lifetime, IHotelServices hotelServices)
        {
            _logger = logger;
            _scope = lifetime;
            _hotelServices = hotelServices;
                            
        }
        public IActionResult Index()
        {
            var model=_scope.Resolve<HotelModelView>();
            model.ListOfHotel();
            return View(model);
        }
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
        public IActionResult SearchHotel(string location, string checkInDate, string checkOutDate, int numberOfGuests)
        {
            HttpContext.Session.SetString("Location", location);

            HttpContext.Session.SetString("CheckInDate", checkInDate);

            HttpContext.Session.SetString("CheckOutDate", checkOutDate);

            HttpContext.Session.SetInt32("NumberOfGuests", numberOfGuests);

            try
            {
                var model = _scope.Resolve<HotelModelView>();
                model.ListOfHotelWithRoom(location, DateTime.Parse(checkInDate), DateTime.Parse(checkOutDate), numberOfGuests);
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
            var location= HttpContext.Session.GetString("Location");

            var checkInDate =DateTime.Parse(HttpContext.Session.GetString("CheckInDate"));

               var checkOutDate = DateTime.Parse(HttpContext.Session.GetString("CheckOutDate"));

              var numberOfGuests=  HttpContext.Session.GetInt32("NumberOfGuests")??0;

            try
            {
                var model = _scope.Resolve<HotelModelView>();
                model.ListOfHotelWithRoomDetails(hotelId, location, checkInDate,checkOutDate, numberOfGuests );
                model.NumberOfGuests = numberOfGuests ;
                model.night = (checkOutDate -checkInDate).Days; ;

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

            var model = _scope.Resolve<RoomDetailsModel>();
            model.RoomDetails(id, checkInDate, checkOutDate, numberOfGuests ?? 0);

            return View(model);
        }

        [HttpPost]
        public IActionResult RoomBook(RoomDetailsModel model)
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

    }
}
