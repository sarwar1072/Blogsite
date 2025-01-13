using Autofac;
using Blogsite.Infrastructure.Entities;
using Blogsite.Infrastructure.Services;
using BlogSite.Web.Areas.Admin.Models;
using DevSkill.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogSite.Web.Models.tourViewModel
{
    public class TourViewModel:AdminBaseModel
    {
        protected ITourServices _tourServices;

        public int TourId { get; set; }
        public string? TourName { get; set; }
        public string? TourUrl { get; set; }
        public string? Destination { get; set; }
        public int MaxiMumPeople { get; set; }
        public int MiniMumPeople { get; set; }
        public string? MapUrl { get; set; }
        public string? Requirements { get; set; }
        public string? CancellationTerm { get; set; }
        public double Price { get; set; }
        public int SpotsAvailable { get; set; }
        public  IList<Tour> TourList { set; get; }
        public int Count {  get; set; } 
        public TourViewModel(IHttpContextAccessor httpContext,ITourServices tourServices):base(httpContext)
        {
            _tourServices = tourServices;
        }
        public TourViewModel() {
        }

        public override void ResolveDependency(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
            _tourServices = _lifetimeScope.Resolve<ITourServices>();
            base.ResolveDependency(lifetimeScope);
        }
        //public void TourDetails(int id)

        //{
        //    var data=_tourServices.GetTourDetails(id);

        //    if(data != null) {
        //        id= data.Id;
        //        TourName = data.TourName;
        //        TourUrl = data.TourUrl; 
        //        Destination = data.Destination; 
        //        MaxiMumPeople = data.MaxiMumPeople;
        //        MiniMumPeople = data.MiniMumPeople;
        //        MapUrl = data.MapUrl;
        //        Requirements = data.Requirements;   
        //        CancellationTerm = data.CancellationTerm;   
        //    }
        //    TourImages = new List<Images>(); 
        //    foreach(var image in data.Images)
        //    {
        //        TourImages.Add(new Images
        //        {
        //            ImageUrl=image.ImageUrl,
        //            AlternativeText=image.AlternativeText,

        //        });  
        //    }
        //}
        public IList<Tour> PopularTourDestination()
        {
            var data = _tourServices.ListOfPopularDestination();
            TourList = new List<Tour>();

            if (data != null)
            {
                foreach (var item in data)
                {
                    TourList.Add(new Tour
                    {
                        Id = item.Id,
                        TourUrl = item.TourUrl,
                        TourName = item.TourName,
                        Destination = item.Destination,
                    });

                }
            }
            return TourList;
        }
        public IList<Tour> ListofTour(string destination)
        {
            var entity = _tourServices.ListOfTour(destination);
            Count = entity.Count;
            TourList=new List<Tour>();
            foreach (var item in entity)
            {
                TourList.Add(new Tour
                {
                    Id = item.Id,
                    TourUrl=item.TourUrl,
                    TourName=item.TourName,
                    Destination=item.Destination,
                    MaxiMumPeople=item.MaxiMumPeople,   
                    MiniMumPeople=item.MiniMumPeople,   
                    Requirements=item.Requirements, 
                    CancellationTerm=item.CancellationTerm, 
                    Price=item.Price,
                    SpotsAvailable=item.SpotsAvailable, 
                });

            }
            return TourList;    
        }
        public IList<Tour> ListOfTours()
        {
            var entity = _tourServices.ListOfPopularTours();
            TourList = new List<Tour>();
            foreach(var tour in entity)
            {
                TourList.Add(new Tour
                {
                    Id = tour.Id,   
                    TourUrl = tour.TourUrl,
                    Destination = tour.Destination,
                    TourName = tour.TourName,
                   Price = tour.Price,
                });
              
            }  
            return TourList;
        }


        //public IList<SelectListItem> ListOfCoverType()
        //{
        //    var cover = new List<SelectListItem>();
        //    foreach (var item in _productService.GetCoverTypes())
        //    {
        //        var addItem = new SelectListItem
        //        {
        //            Text = item.Name,
        //            Value = item.Id.ToString()
        //        };
        //        cover.Add(addItem);
        //    }
        //    return cover;
        //}
        //public IList<SelectListItem> GetAll()
        //{
        //    var model = new List<SelectListItem>();
            
        //        foreach (var tour in _tourServices.ListOfTourName())
        //        {
        //            var addItem = new SelectListItem()
        //            {
        //                Text=tour.Destination,
        //                Value=tour.Id.ToString(),

        //            }; 
        //        model.Add(addItem);
        //        }
        //    return model;            
        //}

    }
}
