using Autofac;
using Blogsite.Infrastructure.Entities;
using Blogsite.Infrastructure.Services;
using DevSkill.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogSite.Web.Areas.Admin.Models.TourModelFolder
{
    public class CreateTour:TourModel
    {
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
        public int TourDetailsId {  get; set; } 

        public CreateTour(IHttpContextAccessor httpContext,ITourServices tourServices):base(httpContext,tourServices) 
        {               
        }
        public CreateTour()
        {    
           //ist = new List<string>();   
        }
      
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
                    TourDetailsId = TourDetailsId,  

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
        public IList<SelectListItem> ListOfTourDetails()
        {
            var listOftour = new List<SelectListItem>();
            foreach (var item in _tourServices.GetTypeOfTour())
            {
                var addItem = new SelectListItem
                {
                    Text = item.Location,
                    Value = item.Id.ToString()
                };
                listOftour.Add(addItem);
            }
            return listOftour;
        }
        public void  RemoveTour(int id) { 
          _tourServices.DeleteTour(id);  
        }
               

    }
}
