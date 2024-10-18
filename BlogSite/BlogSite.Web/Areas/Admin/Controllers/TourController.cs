using Autofac;
using BlogSite.Web.Areas.Admin.Models.TourModelFolder;
using BlogSite.Web.Models;
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
            
            return View();
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
                    if(tour.ListofImages != null)
                    {
                        for (int i = 0; i < tour.ListofImages.Count;i++)
                        {
                            tour.UrlList.Add(_fileHelper.UploadFile(tour.ListofImages[i]));
                        }
                    }
                  await   tour.AddTour();
                }
                catch (Exception ex)
                {
                    _logger.LogError($"{ex.Message}");
                }
            }
            
            return View(tour);
        }
    }
}
