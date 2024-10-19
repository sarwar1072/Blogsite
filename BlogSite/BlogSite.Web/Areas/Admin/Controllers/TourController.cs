using Autofac;
using Autofac.Core.Lifetime;
using BlogSite.Web.Areas.Admin.Models.TourModelFolder;
using BlogSite.Web.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.CodeDom;

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
        public async Task<IActionResult> Add(CreateTour tour)
        {
            tour.ResolveDependency(_scope);
            if(ModelState.IsValid)
            {
                try
                {
                    tour.TourUrl = _fileHelper.UploadFile(tour.CoverPhotoUrl);
                    if (tour.UrlList == null) { 
                        tour.UrlList = new List<string>();  
                    }
                    if(tour.ListofImages != null)
                    {
                        //for (int i = 0; i < tour.ListofImages.Count;i++)
                        //{
                        //    tour.UrlList.Add(_fileHelper.UploadFile(tour.ListofImages[i]));
                        //}
                        foreach (var item in tour.ListofImages)
                        {
                            tour.UrlList.Add(_fileHelper.UploadFile(item));
                        }
                    }
                  await   tour.AddTour();
                  return RedirectToAction(nameof(Index));

                }
                catch (Exception ex)
                {
                    _logger.LogError($"{ex.Message}");
                }
            }           
            return View(tour);
        }
        [HttpPost,ValidateAntiForgeryToken]
        public  ActionResult Delete(int id) 
        {
            try
            {
                var dataDelete = _scope.Resolve<CreateTour>();
                 dataDelete.RemoveTour(id);
                //ViewResponse("Blog has been deleted", ResponseTypes.Success);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}");
                //ViewResponse(ex.Message, ResponseTypes.Error);
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
