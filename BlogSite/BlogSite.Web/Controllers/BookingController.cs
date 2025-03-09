using Autofac;
using Autofac.Core.Lifetime;
using Blogsite.Infrastructure.Services;
using Blogsite.Membership.Services;
using BlogSite.Web.Areas.Admin.Models.VisaFolder;
using BlogSite.Web.Areas.Admin.Models;
using BlogSite.Web.Models;
using BlogSite.Web.Models.BookingModelFolder;
using BlogSite.Web.Models.Travelfolder;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static System.Formats.Asn1.AsnWriter;
using System.Diagnostics;

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
            model.NoOfTraveller();
            return View(model);  
        }
        [HttpPost]
        [Authorize]
        public IActionResult Traveller([FromBody] TravelModel travel)
        {
             Guid UserId = CurrentUser != null ? CurrentUser.Id : Guid.Empty;
            travel.ResolveDependency(_scope);
            travel.AddTraveller(UserId);

            return Json(travel);
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetTravellers()
        {
            Guid UserId = CurrentUser != null ? CurrentUser.Id : Guid.Empty;

            var travellers = _scope.Resolve<TravelModel>();
            travellers.ListOfTravellerByUserId(UserId);
            return PartialView("_ListOfTravellerpartial", travellers); 
        }
        
        public IActionResult DeleteTraveller(int  id) 
        {
            var dataDelete = _scope.Resolve<TravelModel>();

            try
            {
                dataDelete.RemoveTraveller(id);
              //  dataDelete.Response = new ResponseModel("Deleted", ResponseType.Success);
                return RedirectToAction(nameof(Traveller));
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}");
                //dataDelete.Response = new ResponseModel("Failed to delete", ResponseType.Failure);
            }
            return View();  
        }
        public IActionResult EditTraveller(int id)
        {

            var model = _scope.Resolve<TravelModel>();
           var data= model.GetById(id);  
            return Json(data);
        }
        [Authorize]
        public async Task<IActionResult> AccountInfo()
        {
            //  Guid UserId = CurrentUser != null ? CurrentUser.Id : Guid.Empty;
            // var user = await _userManagerAdapter.FindUserId(UserId);
            var model = _scope.Resolve<UserInfoModel>();

            if (CurrentUser != null)
            {
                model.FirstName = CurrentUser.FirstName;
                model.LastName = CurrentUser.LastName;
                model.Email = CurrentUser.Email;
            }

            return View(model);
        }

    }
}


