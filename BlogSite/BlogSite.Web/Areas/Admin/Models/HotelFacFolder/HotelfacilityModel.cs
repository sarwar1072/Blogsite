using Autofac;
using Blogsite.Infrastructure.Services;
using BlogSite.Web.Models;

namespace BlogSite.Web.Areas.Admin.Models.HotelFacFolder
{
    public class HotelfacilityModel:AdminBaseModel
    {
        protected IHotelfacilityServices _hotelfacility;
        public HotelfacilityModel(IHttpContextAccessor httpContext, IHotelfacilityServices hotelfacility) : base(httpContext)
        {
            _hotelfacility = hotelfacility;
        }
        public HotelfacilityModel()
        {
        }
        public override void ResolveDependency(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
            _hotelfacility = _lifetimeScope.Resolve<IHotelfacilityServices>();
            base.ResolveDependency(lifetimeScope);
        }
        
        internal object GetHotelFacilityList(DataTablesAjaxRequestModel dataTables)
        {
            var data = _hotelfacility.GetHotelfacilityList(dataTables.PageIndex,
                                                     dataTables.PageSize,
                                                     dataTables.SearchText,
                                                     dataTables.GetSortText(new string[] { "BusinessFacilities",
                                                     "FitnessFacilities","FoodFacilities"}));
            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.hotels
                        select new string[]
                        {
                            record.BusinessFacilities,
                            record.FitnessFacilities,
                            record.FoodFacilities,
                            record.General,
                            record.IndoorFacitilies,
                            record.Parking,
                            record.Policies,
                            record.Id.ToString()
                        }).ToArray()
            };
        }
    }
}
