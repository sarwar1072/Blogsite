using Autofac;
using Blogsite.Infrastructure.Services;
using BlogSite.Web.Models;

namespace BlogSite.Web.Areas.Admin.Models.VisaFolder
{
    public class VisaModel:AdminBaseModel
    {
        protected IVisaServices _visaServices;
        public VisaModel(IHttpContextAccessor httpContext, IVisaServices visaServices) : base(httpContext)
        {
            _visaServices = visaServices;
        }
        public VisaModel()
        {
        }
        public override void ResolveDependency(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
            _visaServices = _lifetimeScope.Resolve<IVisaServices>();
            base.ResolveDependency(lifetimeScope);
        }
        public void getByid(int id)
        {
            _visaServices.GetByid(id);
        }
        public void getByDestination(string destination)
        {
            _visaServices.ListOfVisa(destination);
        }
        internal object GetVisa(DataTablesAjaxRequestModel dataTables)
        {
            var data = _visaServices.GetVisaList(dataTables.PageIndex,
                                                     dataTables.PageSize,
                                                     dataTables.SearchText,
                                                     dataTables.GetSortText(new string[] {"Destination","Price"}));
            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.visa
                        select new string[]
                        {
                            record.Destination,
                            record.VisaType,
                            record.VisaMode,
                            record.EntryType,
                            record.Price.ToString(),    
                            record.Policy,
                            record.Requirements,
                            record.Id.ToString()
                        }).ToArray()
            };
        }

    }
}
