using Autofac;
using Blogsite.Infrastructure.Entities;
using Blogsite.Infrastructure.Services;

namespace BlogSite.Web.Areas.Admin.Models.TourModelFolder
{
    public class CreateTour:TourModel
    {
        private ITourServices _services;    
        public string? TourName { get; set; }
        public IFormFile CoverPhoto { get; set; }
        public string? TourUrl { get; set; }
        public string? Destination { get; set; }
        public int MaxiMumPeople { get; set; }
        public int MiniMumPeople { get; set; }
        public string? MapUrl { get; set; }
        public string? Requirements { get; set; }
        public string? CancellationTerm { get; set; }
        public double Price { get; set; }
        public int SpotsAvailable { get; set; }
        public IFormFileCollection ListofImages { get; set; }  
        public ICollection<Images>? Images { get; set; }

        public CreateTour(IHttpContextAccessor httpContext,ITourServices tourServices):base(httpContext) 
        {               
            _services = tourServices;   
        }
        public CreateTour()
        {              
        }

        public override void ResolveDependency(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope; 
            _services=_lifetimeScope.Resolve<ITourServices>();
            base.ResolveDependency(lifetimeScope);  
        }




    }
}
