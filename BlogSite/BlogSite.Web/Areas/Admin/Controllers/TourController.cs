using Autofac;
using Autofac.Core.Lifetime;
using Blogsite.Infrastructure;
using Blogsite.Infrastructure.Entities;
using BlogSite.Web.Areas.Admin.Models;
using BlogSite.Web.Areas.Admin.Models.TourModelFolder;
using BlogSite.Web.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.CodeDom;
using System.Security.Cryptography.X509Certificates;

namespace BlogSite.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TourController : Controller
    {
        protected readonly ILifetimeScope _scope;
        IFileHelper _fileHelper;
        protected readonly ILogger<TourController> _logger;  
        public TourController(ILifetimeScope scope,IFileHelper fileHelper,ILogger<TourController> logger)
        {
                _fileHelper = fileHelper;
            _scope = scope; 
            _logger = logger;   
        }
        public IActionResult Index()
        {
            var model = _scope.Resolve<TourModel>();

           return View(model);
        }
        public IActionResult GetTour()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = _scope.Resolve<TourModel>();
            var data = model.GetTour(tableModel);
            return Json(data);
        }
        public async Task<IActionResult> Add()
        {
            var model = _scope.Resolve<CreateTour>();
            return View(model);
        }
        [HttpPost]
        public IActionResult Add(CreateTour tour)
        {
            tour.ResolveDependency(_scope);
            if (ModelState.IsValid)
            {
                try
                {
                    tour.TourUrl = _fileHelper.UploadFile(tour.CoverPhotoUrl);
                    if (tour.UrlList == null)
                    {
                        tour.UrlList = new List<string>();
                    }
                    if (tour.ListofImages != null)
                    {
                        foreach (var item in tour.ListofImages)
                        {
                            tour.UrlList.Add(_fileHelper.UploadFile(item));
                        }
                    }
                    tour.AddTour();
                    tour.Response = new ResponseModel("Added successfully", ResponseType.Success);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    _logger.LogError($"{ex.Message}");
                    tour.Response = new ResponseModel("Fail", ResponseType.Failure);
                }
            }
            return View(tour);
        }
        
       public IActionResult GetById(int id)
        {
            var model=_scope.Resolve<TourModel>(); 
            model.getByid(17);
            return View();
        }
        public IActionResult GetByDestination(string destination)
        {
            var model = _scope.Resolve<TourModel>();
            model.getByDestination("Sundarban");
            return View();
        }
        public IActionResult EditTour(int id)
        {
            var model = _scope.Resolve<EditTourModel>();
            model.Load(id);
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult EditTour(EditTourModel model)
        {
            model.ResolveDependency(_scope);

            if (ModelState.IsValid)
            {
                try
                {
                    if (model.CoverPhotoUrl != null)
                    {
                        _fileHelper.DeleteFile(model.TourUrl);
                        model.TourUrl = _fileHelper.UploadFile(model.CoverPhotoUrl);
                    }
                    model.Edit();
                    model.Response = new ResponseModel("Edited successfully", ResponseType.Success);
                    return RedirectToAction("Index");
                }
                //catch (DuplicationException ex)
                //{
                //    //model.Response = new ResponseModel(ex.Message, ResponseType.Failure);
                //}
                catch (Exception ex)
                {
                    _logger.LogError($"{ex.Message}");

                   model.Response = new ResponseModel("edited fail", ResponseType.Failure);
                }
            }
            return View(model);
        }
        [HttpPost,ValidateAntiForgeryToken]
        public  ActionResult Delete(int id) 
        {
            var dataDelete = _scope.Resolve<CreateTour>();

            try
            {
                dataDelete.RemoveTour(id);
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
