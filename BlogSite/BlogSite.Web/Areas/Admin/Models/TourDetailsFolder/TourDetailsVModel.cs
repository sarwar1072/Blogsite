using Autofac;
using Blogsite.Infrastructure.Services;
using BlogSite.Web.Models;

namespace BlogSite.Web.Areas.Admin.Models.TourDetailsFolder
{
    public class TourDetailsVModel:AdminBaseModel
    {
        protected ITourDetailsServices _tourDetails;
        public TourDetailsVModel(IHttpContextAccessor httpContext, ITourDetailsServices tourDetails) : base(httpContext)
        {
            _tourDetails = tourDetails;
        }
        public TourDetailsVModel()
        {
        }
        public override void ResolveDependency(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
            _tourDetails = _lifetimeScope.Resolve<ITourDetailsServices>();
            base.ResolveDependency(lifetimeScope);
        }

        internal object GetTourdetails(DataTablesAjaxRequestModel dataTables)
        {
            var data = _tourDetails.GetTourdetailsList(dataTables.PageIndex,
                                                     dataTables.PageSize,
                                                     dataTables.SearchText,
                                                     dataTables.GetSortText(new string[] { "Location", "Timing"}));
            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.tours
                        select new string[]
                        {
                            record.Overview,
                            record.Location,
                            record.Timing,
                            record.InclusionExclusion,
                            record.Description,
                            record.AdditionalInformation,
                            record.TravelTips,                           
                            record.Id.ToString()
                        }).ToArray()
            };
        }
    }
}
