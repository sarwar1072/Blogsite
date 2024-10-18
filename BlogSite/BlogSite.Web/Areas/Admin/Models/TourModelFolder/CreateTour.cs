using Autofac;
using Blogsite.Infrastructure.Entities;
using Blogsite.Infrastructure.Services;

namespace BlogSite.Web.Areas.Admin.Models.TourModelFolder
{
    public class CreateTour:TourModel
    {
        private ITourServices _services; 
        public int TourId { get; set; } 
        public string? TourName { get; set; }
        public IFormFile CoverPhotoUrl { get; set; }
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
        public List<string>? UrlList {  get; set; }    
        public ICollection<Images>? Images { get; set; }

        public CreateTour(IHttpContextAccessor httpContext,ITourServices tourServices):base(httpContext) 
        {               
            _services = tourServices;   
        }
        public CreateTour()
        {    
            UrlList = new List<string>();   
        }

        public override void ResolveDependency(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope; 
            _services=_lifetimeScope.Resolve<ITourServices>();
            base.ResolveDependency(lifetimeScope);  
        }

        public async Task AddTour()
        {
            var model = new Tour()
            {
                TourName = TourName, 
                TourUrl = TourUrl,  
                Destination=Destination,    
                MaxiMumPeople = MaxiMumPeople,
                MiniMumPeople = MiniMumPeople,
                MapUrl = MapUrl,
                Requirements = Requirements,
                CancellationTerm =CancellationTerm, 
                Price = Price,  
                SpotsAvailable = SpotsAvailable,    

            };
            model.Images=new List<Images>();    
            if(ListofImages != null) { 
            for(int i=0;i<UrlList.Count;i++) {  
                model.Images.Add(new Images
                {
                    ImageUrl = UrlList[i],
                    AlternativeText="Image not found",
                    TourId=TourId
                }); 

                }  
            }
          await  _services.AddTour(model);    
        }



    }
}
