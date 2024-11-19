using Autofac;
using BlogSite.Web.Areas.Admin.Models;
using BlogSite.Web.Areas.Admin.Models.HotelFacFolder;
using BlogSite.Web.Areas.Admin.Models.HotelmodelFolder;
using BlogSite.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Web.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class HotelFacilityController : Controller
    {
        protected readonly ILifetimeScope _scope;
        public HotelFacilityController(ILifetimeScope lifetimeScope)
        {
                _scope = lifetimeScope;
        }
        public IActionResult Index()
        {
            var model = _scope.Resolve<HotelfacilityModel>();

            return View(model);
        }
        public IActionResult GetHotelFacility()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = _scope.Resolve<HotelfacilityModel>();
            var data = model.GetHotelFacilityList(tableModel);
            return Json(data);
        }
        public IActionResult AddFacility()
        {
            var model = _scope.Resolve<CreateHotelfacility>();
            return View(model);  
        }
        [HttpPost]
        public IActionResult AddFacility(CreateHotelfacility create)
        {
            create.ResolveDependency(_scope);
            if (ModelState.IsValid)
            {
                try
                {

                    create.AddHotelFacility();
                    create.Response = new ResponseModel("Hotel facility added successfully", ResponseType.Success);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    create.Response = new ResponseModel("Fail", ResponseType.Failure);
                }
            }
            return View();
        }

    }
}
