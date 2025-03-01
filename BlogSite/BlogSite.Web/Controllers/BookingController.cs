using Autofac;
using Blogsite.Infrastructure.Services;
using Blogsite.Membership.Services;
using BlogSite.Web.Models.BookingModelFolder;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlogSite.Web.Controllers
{
    public class BookingController : Controller
    {
        private readonly ILogger<VisaController> _logger;
        protected readonly ILifetimeScope _scope;

        public BookingController(ILogger<VisaController> logger, ILifetimeScope lifetime)
        {
            _logger = logger;
            _scope = lifetime;
        }
        [Authorize]
        public IActionResult Index()
        {
            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier); // Get logged-in user ID as string
            Guid userId = Guid.Empty; // Default value in case of conversion failure

            if (!string.IsNullOrEmpty(userIdString) && Guid.TryParse(userIdString, out Guid parsedUserId))
            {
                userId = parsedUserId;
            }

            var model = _scope.Resolve<VisaBookingViewModel>();
            model.GetBookingById(userId);

            return View(model);
        }
        
        [Authorize] 
        public IActionResult BookedHotelList()
        {
            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier); // Get logged-in user ID as string
            Guid userId = Guid.Empty; // Default value in case of conversion failure

            if (!string.IsNullOrEmpty(userIdString) && Guid.TryParse(userIdString, out Guid parsedUserId))
            {
                userId = parsedUserId;
            }

            var model = _scope.Resolve<HotelBookingModel>();
            model.GetHotelBookingList(userId);
            return View(model); 
        }
        //public IActionResult TourBookingAction(int tourId)
        //{
        //    return View();  
        //}

    }
}
