using Autofac;

namespace BlogSite.Web.Areas.Admin.Models.TourModelFolder
{
    public class TourModel : AdminBaseModel
    {
        public TourModel(IHttpContextAccessor httpContext) : base(httpContext) { }
        public TourModel()
        {
        }
        public override void ResolveDependency(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
            base.ResolveDependency(lifetimeScope);
        }
    }
}
