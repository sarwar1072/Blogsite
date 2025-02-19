using Autofac;
using Blogsite.Infrastructure.Entities;
using BlogSite.Web.Areas.Admin.Models;
using BlogSite.Web.Areas.Admin.Models.HotelmodelFolder;
using BlogSite.Web.Areas.Admin.Models.TourModelFolder;
using BlogSite.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "User, Admin")]

    public class HotelController : Controller
    {
        protected readonly ILifetimeScope _scope;
        IFileHelper _fileHelper;
        protected readonly ILogger<TourController> _logger;
        public HotelController(ILifetimeScope scope, IFileHelper fileHelper, ILogger<TourController> logger)
        {
            _fileHelper = fileHelper;
            _scope = scope;
            _logger = logger;
        }
        public IActionResult Index()
        {
            var model = _scope.Resolve<HotelModel>();

            return View(model);
        }
        public IActionResult GetHotel()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = _scope.Resolve<HotelModel>();
            var data = model.GetHotelList(tableModel);
            return Json(data);
        }

        public IActionResult AddHotel() 
        {
            var model = _scope.Resolve<CreateHotelModel>();
            return View(model);
        }
        [HttpPost]  
        public IActionResult AddHotel(CreateHotelModel model) 
        {
            model.ResolveDependency(_scope);
            if (ModelState.IsValid)
            {
                try
                {
                    model.HotelUrl = _fileHelper.UploadFile(model.formFile);
                    if (model.UrlList == null)
                    {
                        model.UrlList = new List<string>();
                    }
                    if (model.ListofImages != null)
                    {
                        foreach (var item in model.ListofImages)
                        {
                            model.UrlList.Add(_fileHelper.UploadFile(item));
                        }
                    }
                    model.addHotel();
                    model.Response = new ResponseModel("Hotel added successfully", ResponseType.Success);
                    return RedirectToAction("Index"); 
                }
                catch (Exception ex)
                {
                    _logger.LogError($"{ex.Message}");
                    model.Response = new ResponseModel("Fail", ResponseType.Failure);
                }
            }
            return View();        
        }
        public IActionResult EditHotel(int id)
        {
            var model = _scope.Resolve<EditHotelModel>();
            model.Load(id);
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult EditHotel(EditHotelModel model)
        {
            model.ResolveDependency(_scope);

            if (ModelState.IsValid)
            {
                try
                {
                    if (model.formFile != null)
                    {
                        _fileHelper.DeleteFile(model.HotelUrl);
                        model.HotelUrl = _fileHelper.UploadFile(model.formFile);
                    }
                    model.editHotel();
                    model.Response = new ResponseModel("Hotel edited successfully", ResponseType.Success);
                    return RedirectToAction("Index");
                }
                //catch (DuplicationException ex)
                //{
                //    //model.Response = new ResponseModel(ex.Message, ResponseType.Failure);
                //}
                catch (Exception ex)
                {
                    _logger.LogError($"{ex.Message}");

                    model.Response = new ResponseModel("hotel edited fail", ResponseType.Failure);
                }
            }
            return View(model);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var dataDelete = _scope.Resolve<EditHotelModel>();

            try
            {
                dataDelete.DeleteHotel(id);
                dataDelete.Response = new ResponseModel("Deleted", ResponseType.Success);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}");
                dataDelete.Response = new ResponseModel("Failed to delete", ResponseType.Failure);
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
