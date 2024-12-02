using Autofac;
using BlogSite.Web.Areas.Admin.Models;
using BlogSite.Web.Areas.Admin.Models.RoomFolder;
using BlogSite.Web.Areas.Admin.Models.TourModelFolder;
using BlogSite.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoomController : Controller
    {
        protected readonly ILifetimeScope _scope;
        private IFileHelper _fileHelper;
        protected readonly ILogger<TourController> _logger;
        public RoomController(ILifetimeScope scope, IFileHelper fileHelper, ILogger<TourController> logger)
        {
            _fileHelper = fileHelper;
            _scope = scope;
            _logger = logger;
        }
        public IActionResult Index()
        {
            var model = _scope.Resolve<RoomModel>();
            return View(model);
        }
        public IActionResult GetRoom()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = _scope.Resolve<RoomModel>();
            var data = model.GetRoomList(tableModel);
            return Json(data);
        }

        public IActionResult AddRoom()
        {
            var model = _scope.Resolve<CreateRoomModel>();
            //model.ListOfHotelName();
            return View(model);
        }
        [HttpPost]
        public IActionResult AddRoom(CreateRoomModel model)
        {
            model.ResolveDependency(_scope);
            if (ModelState.IsValid)
            {
                try
                {
                    model.RoomPhUrl = _fileHelper.UploadFile(model.formFile);
                    
                    model.addRoom();
                    model.Response = new ResponseModel("Room added successfully", ResponseType.Success);
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
        public IActionResult EditRoom(int id)
        {
            var model = _scope.Resolve<EditRoomModel>();
            model.Load(id);
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult EditRoom(EditRoomModel model)
        {
            model.ResolveDependency(_scope);

            if (ModelState.IsValid)
            {
                try
                {
                    if (model.formFile != null)
                    {
                        _fileHelper.DeleteFile(model.RoomPhUrl);
                        model.RoomPhUrl = _fileHelper.UploadFile(model.formFile);
                    }
                    model.EditRoom();
                    model.Response = new ResponseModel("Edited successfully", ResponseType.Success);
                    return RedirectToAction("Index");
                }             
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
            var dataDelete = _scope.Resolve<EditRoomModel>();

            try
            {
                dataDelete.RemoveRoom(id);
                dataDelete.Response = new ResponseModel("RoomdDeleted", ResponseType.Success);
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
