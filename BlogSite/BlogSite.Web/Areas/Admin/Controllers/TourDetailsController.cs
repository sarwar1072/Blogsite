using Autofac;
using Blogsite.Infrastructure.Entities;
using BlogSite.Web.Areas.Admin.Models;
using BlogSite.Web.Areas.Admin.Models.TourDetailsFolder;
using BlogSite.Web.Areas.Admin.Models.TourModelFolder;
using BlogSite.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TourDetailsController : Controller
    {
        protected readonly ILifetimeScope _scope;
        public TourDetailsController(ILifetimeScope scope)
        {
                _scope = scope;
        }
        public IActionResult Index()
        {
            var model = _scope.Resolve<TourDetailsVModel>();
            return View(model);
        }
        public IActionResult GetDetails()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = _scope.Resolve<TourDetailsVModel>();
            var data = model.GetTourdetails(tableModel);
            return Json(data);
        }
        public IActionResult AddTourDetails()
        {
            var model=_scope.Resolve<CreateTourDetails>();
            return View(model);
        }
        [HttpPost]
        public IActionResult AddTourDetails(CreateTourDetails model)
        {
            model.ResolveDependency(_scope);
            if (ModelState.IsValid)
            {
                try
                {
                    model.AddTourDetails();
                    model.Response = new ResponseModel("Added successfully", ResponseType.Success);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                   // _logger.LogError($"{ex.Message}");
                    model.Response = new ResponseModel("Fail", ResponseType.Failure);
                }
            }

            return View(model);
        }

        public IActionResult EditTourDetails(int id)
        {
            var model = _scope.Resolve<EditTourDetails>();
            model.Load(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult EditTourDetails(EditTourDetails model)
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
                catch (Exception ex)
                {
                    // _logger.LogError($"{ex.Message}");
                    model.Response = new ResponseModel("Fail", ResponseType.Failure);
                }
            }

            return View(model);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var dataDelete = _scope.Resolve<CreateTourDetails>();

            try
            {
                dataDelete.RemoveTour(id);
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
