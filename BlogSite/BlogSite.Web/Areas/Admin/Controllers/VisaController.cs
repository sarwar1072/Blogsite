using Autofac;
using BlogSite.Web.Areas.Admin.Models;
using BlogSite.Web.Areas.Admin.Models.TourModelFolder;
using BlogSite.Web.Areas.Admin.Models.VisaFolder;
using BlogSite.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class VisaController : Controller
    {
        protected readonly ILifetimeScope _scope;
        IFileHelper _fileHelper;
        protected readonly ILogger<VisaController> _logger;
        public VisaController(ILifetimeScope scope, IFileHelper fileHelper, ILogger<VisaController> logger)
        {
            _fileHelper = fileHelper;
            _scope = scope;
            _logger = logger;
        }
        public IActionResult Index()
        {
            var model = _scope.Resolve<VisaModel>();

            return View(model);
        }
        public IActionResult GetVisa()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = _scope.Resolve<VisaModel>();
            var data = model.GetVisa(tableModel);
            return Json(data);
        }
        public async Task<IActionResult> Add()
        {
            var model = _scope.Resolve<CreateVisaModel>();
            return View(model);
        }
        [HttpPost]
        public IActionResult Add(CreateVisaModel visa)
        {
            visa.ResolveDependency(_scope);
            if (ModelState.IsValid)
            {
                try
                {
                    if (visa.CoverPhotoUrl != null)
                    {
                        visa.CoverUrl = _fileHelper.UploadFile(visa.CoverPhotoUrl);
                    }
                    if (visa.CardPhotoUrl != null)
                    {
                        visa.CardUrl = _fileHelper.UploadFile(visa.CardPhotoUrl);
                    }
                    //visa.CoverUrl = _fileHelper.UploadFile(visa.CoverPhotoUrl);
                    //visa.CardUrl = _fileHelper.UploadFile(visa.CardPhotoUrl);

                    visa.AddVisa();
                    visa.Response = new ResponseModel("Added successfully", ResponseType.Success);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    _logger.LogError($"{ex.Message}");
                    visa.Response = new ResponseModel("Fail to create", ResponseType.Failure);
                }
            }
            return View(visa);
        }
        public IActionResult EditVisa(int id)
        {
            var model = _scope.Resolve<EditVisaModel>();
            model.Load(id);
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult EditVisa(EditVisaModel model)
        {
            model.ResolveDependency(_scope);

            if (ModelState.IsValid)
            {
                try
                {
                    //if (model.CoverPhotoUrl != null)
                    //{
                    //    _fileHelper.DeleteFile(model.CoverUrl);
                    //    model.CoverUrl = _fileHelper.UploadFile(model.CoverPhotoUrl);
                    //}
                    //if (model.CardPhotoUrl != null)
                    //{
                    //    _fileHelper.DeleteFile(model.CardUrl);
                    //    model.CardUrl = _fileHelper.UploadFile(model.CardPhotoUrl);
                    //}
                    model.EditVisa();
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
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var dataDelete = _scope.Resolve<EditVisaModel>();

            try
            {
                dataDelete.RemoveVisa(id);
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
