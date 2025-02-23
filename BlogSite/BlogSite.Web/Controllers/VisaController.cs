using Autofac;
using Blogsite.Infrastructure.Entities;
using Blogsite.Infrastructure.Services;
using Blogsite.Membership.BusinessObj;
using Blogsite.Membership.Services;
using BlogSite.Web.Models.tourViewModel;
using BlogSite.Web.Models.VisaViewModelFolder;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlogSite.Web.Controllers
{
    public class VisaController : Controller
    {
        private readonly ILogger<VisaController> _logger;
        protected readonly ILifetimeScope _scope;
        private IVisaServices _visaServices;
        protected IUserManagerAdapter<ApplicationUser> _userManagerAdapter;

        public VisaController(ILogger<VisaController> logger, ILifetimeScope lifetime, IVisaServices visaServices
            , IUserManagerAdapter<ApplicationUser> userManagerAdapter)
        {
            _logger = logger;
            _scope = lifetime;
            _visaServices = visaServices;
            _userManagerAdapter = userManagerAdapter;   

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
        public async Task<IActionResult> ConfirmForm(int Id)
        {
            try
            {
                var model = _scope.Resolve<VisaConfirmFormModel>();
                model.VisaById(Id);

                var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier); // Get logged-in user ID as string
                Guid userId = Guid.Empty; // Default value in case of conversion failure

                if (!string.IsNullOrEmpty(userIdString) && Guid.TryParse(userIdString, out Guid parsedUserId))
                {
                    userId = parsedUserId;
                }

                // Now `userId` contains a valid `Guid` or `Guid.Empty` if conversion failed

                if (userId == Guid.Empty)
                {
                    // Redirect to login with returnUrl
                    return RedirectToAction("Login", "Account", new
                    {
                        returnUrl = Url.Action("ConfirmForm", "Visa", new { Id = Id })
                    });
                }

                //If user is logged in, pre - fill user details
                var user =await _userManagerAdapter.FindUserId(userId);
                if (user != null)
                {
                    model.Name = user.FirstName;
                    model.Email = user.Email;
                    model.UserId = user.Id;              
                };
                return View(model);
            }
            catch (Exception e)
            {
                _logger.LogError($"{e.Message}");
                ViewBag.Message = "Error";
            }

            return View();  
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ConfirmForm(VisaConfirmFormModel model)
        {
            try
            {
                model.ResolveDependency(_scope);

                model.AddUserForm();
                return RedirectToAction("WishPage");

            }
            catch (Exception e)
            {
                _logger.LogError($"{e.Message}");
                ViewBag.Message = "Error";
            }

            return View();
        }
        public IActionResult WishPage()
        {
            return View();
        }




    }
}
