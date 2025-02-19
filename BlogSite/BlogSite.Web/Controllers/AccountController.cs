using Autofac;
using BlogSite.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Web.Controllers
{
    public class AccountController : Controller
    {
        protected readonly ILogger<AccountController> _logger;

        protected readonly ILifetimeScope _lifetimeScope;
        public AccountController(ILifetimeScope scope, ILogger<AccountController> logger)
        {
                _lifetimeScope = scope;
            _logger = logger;   
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Register(string returnUrl = null!)
        {
            var model = _lifetimeScope.Resolve<RegisterModel>();
            model.ReturnUrl = returnUrl;
            await model.GetExternalAuthenticationSchemesAsync();
            return View(model);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            model.Resolve(_lifetimeScope);
            model.ReturnUrl ??= Url.Content("~/");
            //ViewData["ReturnUrl"] = returnUrl ?? Url.Content("~/");

            await model.GetExternalAuthenticationSchemesAsync();

            if (ModelState.IsValid)
            {
                try
                {
                    var result = await model.CreateAsync();
                    if (result.Succeeded)
                    {
                        // await model.AdduserProfile(model.UserId);
                        if (model.RequireConfirmedAccount())
                        {
                            return RedirectToAction("RegisterConfirmation", new { email = model.Email, returnUrl = model.ReturnUrl });
                        }
                        else
                        {
                            return RedirectToAction("Index", "Question", new { area = "ForPost" });
                        }
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
                catch (InvalidOperationException ex)
                {
                    _logger.LogError(ex, ex.Message);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, ex.Message);
                }
            }
            return View(model);
        }
        public async Task<IActionResult> RegisterConfirmation(string email, string returnUrl = null)
        {
            var model = _lifetimeScope.Resolve<RegistrationConfirmationModel>();
            var registerModel = _lifetimeScope.Resolve<RegisterModel>();

            if (email == null)
            {
                return RedirectToAction("Register");
            }

            try
            {
                var user = await registerModel.FindByEmailAsync(email);
                if (user == null)
                {
                    return NotFound($"Unable to load user with email '{email}'.");
                }

                model.Email = email;
                // await registerModel.EmailConfirmationTokenAsync();
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError(ex, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }

            return View();
        }


    }
}
