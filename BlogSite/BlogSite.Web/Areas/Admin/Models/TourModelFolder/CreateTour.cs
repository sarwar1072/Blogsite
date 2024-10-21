using Autofac;
using Blogsite.Infrastructure.Entities;
using Blogsite.Infrastructure.Services;
using DevSkill.Http;
using Microsoft.AspNetCore.Http;

namespace BlogSite.Web.Areas.Admin.Models.TourModelFolder
{
    public class CreateTour:TourModel
    {
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


        public CreateTour(IHttpContextAccessor httpContext,ITourServices tourServices):base(httpContext,tourServices) 
        {               
        }
        public CreateTour()
        {    
           //ist = new List<string>();   
        }

        //public override void ResolveDependency(ILifetimeScope lifetimeScope)
        //{
        //    _lifetimeScope = lifetimeScope; 
        //    base.ResolveDependency(lifetimeScope);  
        //}

        public void  AddTour()
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
                if(UrlList != null) { 
                    for(int i=0;i<UrlList.Count;i++) 
                    {  
                        model.Images.Add(new Images
                        {
                            ImageUrl = UrlList[i],
                            AlternativeText=$"{model.TourName} image",
                        }); 

                    }            
                }
            _tourServices.AddTour(model);    
        }
        public void  RemoveTour(int id) { 
          _tourServices.DeleteTour(id);  
        }
        public void Edit()
        {
            var model = new Tour()
            {
                Id=TourId,
                TourName = TourName,
                TourUrl = TourUrl,
                Destination = Destination,
                MaxiMumPeople = MaxiMumPeople,
                MiniMumPeople = MiniMumPeople,
                Requirements = Requirements,
                CancellationTerm = CancellationTerm,
                Price = Price,
                SpotsAvailable = SpotsAvailable,

            }; 
            _tourServices.EditTour(model);
        }
        public void Load(int id)
        {
            var dataByid=_tourServices.GetByid(id);
            if(dataByid != null) 
            {
                TourId = dataByid.Id;   
                TourName = dataByid.TourName;
                TourUrl= dataByid.TourUrl;  
                Destination = dataByid.Destination; 
                MaxiMumPeople= dataByid.MaxiMumPeople;  
                MiniMumPeople= dataByid.MiniMumPeople;
                Requirements = dataByid.Requirements;
                CancellationTerm= dataByid.CancellationTerm;
                Price = dataByid.Price;
                SpotsAvailable = dataByid.SpotsAvailable;          
            }
        }

    }
}
