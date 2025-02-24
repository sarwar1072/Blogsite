using Autofac;
using Blogsite.Infrastructure.Services;
using BlogSite.Web.Models.HotelViewM;
using Microsoft.AspNetCore.Authorization;
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
            if (string.IsNullOrEmpty(location))
            {
                _logger.LogWarning("Location is empty!");
                return View();
            }
            HttpContext.Session.SetString("Location", location );
            HttpContext.Session.SetString("CheckInDate", checkInDate );
            HttpContext.Session.SetString("CheckOutDate", checkOutDate );
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
            var location = HttpContext.Session.GetString("Location");
            if (string.IsNullOrEmpty(location))
            {
                location = "Dhaka";
                HttpContext.Session.SetString("Location", location);
            }

            var checkInDateStr = HttpContext.Session.GetString("CheckInDate");
            DateTime checkInDate;
            if (string.IsNullOrEmpty(checkInDateStr) || !DateTime.TryParse(checkInDateStr, out checkInDate))
            {
                checkInDate = DateTime.Now.AddDays(2);
                HttpContext.Session.SetString("CheckInDate", checkInDate.ToString("yyyy-MM-dd"));
            }

            var checkOutDateStr = HttpContext.Session.GetString("CheckOutDate");
            DateTime checkOutDate;
            if (string.IsNullOrEmpty(checkOutDateStr) || !DateTime.TryParse(checkOutDateStr, out checkOutDate))
            {
                checkOutDate = DateTime.Now.AddDays(7);
                HttpContext.Session.SetString("CheckOutDate", checkOutDate.ToString("yyyy-MM-dd"));
            }

            var numberOfGuests = HttpContext.Session.GetInt32("NumberOfGuests") ?? 0;
            if (numberOfGuests <= 0)
            {
                numberOfGuests = 1;
                HttpContext.Session.SetInt32("NumberOfGuests", numberOfGuests);
            }
            

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
        [Authorize]
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
