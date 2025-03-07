using Autofac;
using Autofac.Core.Lifetime;
using Blogsite.Infrastructure.Services;
using Blogsite.Membership.Services;
using BlogSite.Web.Models;
using BlogSite.Web.Models.BookingModelFolder;
using BlogSite.Web.Models.Travelfolder;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlogSite.Web.Controllers
{
    public class BookingController : BaseController
    {
        private readonly ILogger<VisaController> _logger;
        protected readonly ILifetimeScope _scope;

        public BookingController(ILogger<VisaController> logger, ILifetimeScope lifetime,IUserAccessor userAccessor):base(userAccessor)
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
        public IActionResult Support()
        {
            return View();
        }
        public IActionResult Traveller()
        {
            var model=_scope.Resolve<TravelModel>();    
            return View(model);  
        }
        [HttpPost]
        [Authorize]
        public IActionResult Traveller([FromBody] TravelModel travel)
        {
             Guid UserId = CurrentUser != null ? CurrentUser.Id : Guid.Empty;
            travel.ResolveDependency(_scope);
            travel.AddTraveller(UserId);

            return View();
        }


        [Authorize]
        public async Task<IActionResult> AccountInfo()
        {
            
          //  Guid UserId = CurrentUser != null ? CurrentUser.Id : Guid.Empty;
            // var user = await _userManagerAdapter.FindUserId(UserId);
            var model = _scope.Resolve<UserInfoModel>();

            if (CurrentUser != null)
            {
               model.FirstName= CurrentUser.FirstName;  
                model.LastName= CurrentUser.LastName;   
                model.Email= CurrentUser.Email; 
            }
                           
            return View(model);
        }


    }
}
