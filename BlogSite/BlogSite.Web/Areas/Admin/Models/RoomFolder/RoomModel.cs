using Autofac;
using Blogsite.Infrastructure.Services;
using BlogSite.Web.Models;

namespace BlogSite.Web.Areas.Admin.Models.RoomFolder
{
    public class RoomModel:AdminBaseModel
    {
        protected IRoomServices _services;
        public RoomModel(IHttpContextAccessor httpContext, IRoomServices services) : base(httpContext)
        {
            _services =services ;
        }
        public RoomModel()
        {
        }
        public override void ResolveDependency(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
            _services = _lifetimeScope.Resolve<IRoomServices>();
            base.ResolveDependency(lifetimeScope);
        }
        //public void getByid(int id)
        //{
        //  //  _tourServices.TourDetailsById(id);
        //}
        //public void getByDestination(string destination)
        //{
        //    //_tourServices.ListOfTour(destination);
        //}
        internal object GetRoomList(DataTablesAjaxRequestModel dataTables)
        {
            var data = _services.GetRoomList(dataTables.PageIndex,
                                                     dataTables.PageSize,
                                                     dataTables.SearchText,
                                                     dataTables.GetSortText(new string[] { "Name",
                                                     "Location","PricePerNight"}));
            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.rooms
                        select new string[]
                        {
                            record.RoomNumber.ToString(),
                            record.RoomType,
                            record.Price.ToString(),
                            record.RoomPhUrl,                         
                            record.Id.ToString()
                        }).ToArray()
            };
        }

    }
}
