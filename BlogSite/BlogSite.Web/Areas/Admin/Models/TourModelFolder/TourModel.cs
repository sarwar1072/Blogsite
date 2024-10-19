using Autofac;
using Blogsite.Infrastructure.Services;
using BlogSite.Web.Models;

namespace BlogSite.Web.Areas.Admin.Models.TourModelFolder
{
    public class TourModel : AdminBaseModel
    {
        protected  ITourServices _tourServices;
        public TourModel(IHttpContextAccessor httpContext,ITourServices tourServices) : base(httpContext) 
        {
            _tourServices = tourServices;
        }
        public TourModel()
        {
        }
        public override void ResolveDependency(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
            _tourServices=_lifetimeScope.Resolve<ITourServices>();
            base.ResolveDependency(lifetimeScope);
        }

        internal object GetTour(DataTablesAjaxRequestModel dataTables)
        {
            var data = _tourServices.GetTourList(dataTables.PageIndex,
                                                     dataTables.PageSize,
                                                     dataTables.SearchText,
                                                     dataTables.GetSortText(new string[] { "TourName",
                                                     "Destination","Price"}));
            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.tours
                        select new string[]
                        {
                            record.TourName,
                            record.TourUrl,
                            record.Destination,
                            record.Requirements,
                            record.CancellationTerm,
                            record.Price.ToString(),
                            record.SpotsAvailable.ToString(),
                            record.Id.ToString()
                        }).ToArray()
            };
        }


    }
}
