using Blogsite.Infrastructure.Entities;
using Blogsite.Infrastructure.Services;

namespace BlogSite.Web.Areas.Admin.Models.TourDetailsFolder
{
    public class EditTourDetails:TourDetailsVModel
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
        public EditTourDetails(IHttpContextAccessor httpContext, ITourDetailsServices tourDetails) : base(httpContext, tourDetails)
        {
        }
        public EditTourDetails() { }

        public void EditDetails()
        {
            var model = new TourDetails()
            {
                Id = Id,   
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
            _tourDetails.EditDetails(model);
        }
        public void Load(int id)
        {
            var dataByid = _tourDetails.GetByid(id);
            if (dataByid != null)
            {
                Id = dataByid.Id;
                Overview = dataByid.Overview;
                Location = dataByid.Location;
                Timing = dataByid.Timing;
                InclusionExclusion = dataByid.InclusionExclusion;
                Description = dataByid.Description;
                AdditionalInformation = dataByid.AdditionalInformation;
                TravelTips = dataByid.TravelTips;
                Policy = dataByid.Policy;
                Options = dataByid.Options;
            }
        }


    }
}
