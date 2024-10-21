using Blogsite.Infrastructure.Entities;
using Blogsite.Infrastructure.Services;

namespace BlogSite.Web.Areas.Admin.Models.TourModelFolder
{
    public class EditTourModel:TourModel
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

        public EditTourModel(IHttpContextAccessor httpContext, ITourServices tourServices) : base(httpContext, tourServices)
        {
        }
        public EditTourModel()
        {
        }

        public void Edit()
        {
            var model = new Tour()
            {
                Id = TourId,
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
            var dataByid = _tourServices.GetByid(id);
            if (dataByid != null)
            {
                TourId = dataByid.Id;
                TourName = dataByid.TourName;
                TourUrl = dataByid.TourUrl;
                Destination = dataByid.Destination;
                MaxiMumPeople = dataByid.MaxiMumPeople;
                MiniMumPeople = dataByid.MiniMumPeople;
                Requirements = dataByid.Requirements;
                CancellationTerm = dataByid.CancellationTerm;
                Price = dataByid.Price;
                SpotsAvailable = dataByid.SpotsAvailable;
            }
        }
    }
}
