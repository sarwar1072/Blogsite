using Autofac;
using Blogsite.Infrastructure.Entities;
using Blogsite.Infrastructure.Services;
using BlogSite.Web.Areas.Admin.Models;

namespace BlogSite.Web.Models.tourViewModel
{
    public class TourDetailsModel:AdminBaseModel
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
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? EmailAddress { get; set; }
        public string? PhoneNumber { get; set; }
        public string? PreferredJourneyDate { get; set; }
        public string? AdditionalRequirements { get; set; }
        public IList<Tour> TourList { set; get; }
        public IList<Images> TourImages { set; get; }
        public int Count { get; set; }

        public TourDetails TourDetails { get; set; }    =new TourDetails();
        public ConsultationForm ConsultationForm { get; set; }=new ConsultationForm();  
        public TourDetailsModel(IHttpContextAccessor httpContext, ITourServices tourServices) : base(httpContext)
        {
            _tourServices = tourServices;
        }
        public TourDetailsModel()
        {
            TourImages = new List<Images>();
        }

        public override void ResolveDependency(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
            _tourServices = _lifetimeScope.Resolve<ITourServices>();
            base.ResolveDependency(lifetimeScope);
        }
        public void AddConsult()
        {
            var model = new ConsultationForm()
            {
                  FirstName = FirstName, 
                  LastName = LastName,
                  EmailAddress = EmailAddress,  
                  PhoneNumber = PhoneNumber,
                  PreferredJourneyDate = PreferredJourneyDate,
                  AdditionalRequirements = AdditionalRequirements,

            };
            _tourServices.AddConsulationForm(model);    
        }
        public void GetTourDetails(int id)

        {
            var data = _tourServices.GetTourDetails(id);

            if (data != null)
            {
                TourId = data.Id;
                TourName = data.TourName;
                TourUrl = data.TourUrl;
                Destination = data.Destination;
                MaxiMumPeople = data.MaxiMumPeople;
                MiniMumPeople = data.MiniMumPeople;
                MapUrl = data.MapUrl;
                Requirements = data.Requirements;
                CancellationTerm = data.CancellationTerm;
            }
            TourDetails = new TourDetails()
            {
                Overview=data.TourDetails.Overview,
                Location=data.TourDetails.Location, 
                Timing=data.TourDetails.Timing, 
                InclusionExclusion=data.TourDetails.InclusionExclusion, 
                Description=data.TourDetails.Description,   
                AdditionalInformation=data.TourDetails.AdditionalInformation,
                TravelTips=data.TourDetails.TravelTips, 
                Options=data.TourDetails.Options,
                Policy=data.TourDetails.Policy,               
            };
            TourImages = new List<Images>();
            foreach (var image in data.Images)
            {
                TourImages.Add(new Images
                {
                    ImageUrl = image.ImageUrl,
                    AlternativeText = image.AlternativeText,

                });
            }
        }

    }
}

