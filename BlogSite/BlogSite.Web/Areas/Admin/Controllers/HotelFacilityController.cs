using Autofac;
using BlogSite.Web.Areas.Admin.Models;
using BlogSite.Web.Areas.Admin.Models.HotelFacFolder;
using BlogSite.Web.Areas.Admin.Models.HotelmodelFolder;
using BlogSite.Web.Areas.Admin.Models.TourModelFolder;
using BlogSite.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "User, Admin")]

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
        public IActionResult EditHotelFascilities(int id)
        {
            var model = _scope.Resolve<EditHotelfacility>();
            model.Load(id);
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult EditHotelFascilities(EditHotelfacility model)
        {
            model.ResolveDependency(_scope);

            if (ModelState.IsValid)
            {
                try
                {
                   
                    model.EditDetails();
                    model.Response = new ResponseModel("Edited successfully", ResponseType.Success);
                    return RedirectToAction("Index");
                }
                //catch (DuplicationException ex)
                //{
                //    //model.Response = new ResponseModel(ex.Message, ResponseType.Failure);
                //}
                catch (Exception ex)
                {
                   // _logger.LogError($"{ex.Message}");

                    model.Response = new ResponseModel("edited fail", ResponseType.Failure);
                }
            }
            return View(model);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var dataDelete = _scope.Resolve<EditHotelfacility>();

            try
            {
                dataDelete.RemoveHotelfasci(id);
                dataDelete.Response = new ResponseModel("Deleted", ResponseType.Success);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                //_logger.LogError($"{ex.Message}");
                dataDelete.Response = new ResponseModel("Failed to delete", ResponseType.Failure);
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
