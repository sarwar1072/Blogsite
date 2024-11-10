using Autofac;
using Blogsite.Infrastructure.Services;
using BlogSite.Web.Models;

namespace BlogSite.Web.Areas.Admin.Models.HotelmodelFolder
{
    public class HotelModel:AdminBaseModel
    {
        protected IHotelServices _hotelServices;
        public HotelModel(IHttpContextAccessor httpContext, IHotelServices hotelServices) : base(httpContext)
        {
            _hotelServices =hotelServices ;
        }
        public HotelModel()
        {
        }
        public override void ResolveDependency(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
            _hotelServices = _lifetimeScope.Resolve<IHotelServices>();
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
        internal object GetHotelList(DataTablesAjaxRequestModel dataTables)
        {
            var data = _hotelServices.GetHotelList(dataTables.PageIndex,
                                                     dataTables.PageSize,
                                                     dataTables.SearchText,
                                                     dataTables.GetSortText(new string[] { "Name",
                                                     "Location","PricePerNight"}));
            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.hotels
                        select new string[]
                        {
                            record.Name,
                            record.Location,
                            record.HotelUrl,
                            record.PricePerNight.ToString(),
                            record.AvailableRooms.ToString(),                         
                            record.Id.ToString()
                        }).ToArray()
            };
        }

    }
}
