using Blogsite.Infrastructure.Entities;
using Blogsite.Infrastructure.Services;

namespace BlogSite.Web.Areas.Admin.Models.TourDetailsFolder
{
    public class CreateTourDetails:TourDetailsVModel
    {
        public int Id { get; set; }
        public string? Overview { get; set; }
        public string? Location { get; set; }
        public string? Timing { get; set; }
        public string? InclusionExclusion { get; set; }
        public string? Description { get; set; }
        public string? AdditionalInformation { get; set; }
        public string? TravelTips { get; set; }
        public string? Options { get; set; }
        public string? Policy { get; set; }
        public CreateTourDetails(IHttpContextAccessor httpContext, ITourDetailsServices  tourDetails) : base(httpContext, tourDetails)
        {
        }
        public CreateTourDetails() { }
        
        public void AddTourDetails()
        {
            var model = new TourDetails()
            {
                Overview = Overview,
                Location = Location,
                Timing = Timing,
                InclusionExclusion = InclusionExclusion,
                Description = Description,
                AdditionalInformation = AdditionalInformation,
                TravelTips = TravelTips,    
                Policy = Policy,
                Options = Options,
            };
            _tourDetails.AddTourDetails(model);           
        }

    }
}
