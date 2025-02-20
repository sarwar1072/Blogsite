using Blogsite.Infrastructure.Entities;
using Blogsite.Infrastructure.Services;

namespace BlogSite.Web.Areas.Admin.Models.VisaFolder
{
    public class EditVisaModel:VisaModel
    {
        public int Id { get; set; }
        public string? Destination { get; set; }
        public string? CoverUrl { get; set; }
        public IFormFile CoverPhotoUrl { get; set; }
        public string? CardUrl { get; set; }
        public IFormFile CardPhotoUrl { get; set; }
        public string? VisaType { get; set; }
        public string? VisaMode { get; set; }
        public string? EntryType { get; set; }
        public int? VisaValidity { get; set; }
        public int? ProcessingTime { get; set; }
        public int? MaxiMumStay { get; set; }
        public double Price { get; set; }
        public string? Requirements { get; set; }
        public string? Policy { get; set; }
        public EditVisaModel(IHttpContextAccessor httpContext, IVisaServices visaServices) : base(httpContext, visaServices) { }

        public EditVisaModel() { }

        public void EditVisa()
        {
            var model = new Visa()
            {
                Destination = Destination,
                CoverUrl = CoverUrl,
                CardUrl = CardUrl,
                VisaType = VisaType,
                VisaMode = VisaMode,
                EntryType = EntryType,
                VisaValidity = VisaValidity,
                ProcessingTime = ProcessingTime,
                MaxiMumStay = MaxiMumStay,
                Price = Price,
                Requirements = Requirements,
                Policy = Policy,

            };

            _visaServices.EditVisa(model);
        }
        public void Load(int id)
        {
            var dataByid = _visaServices.GetByid(id);
            if (dataByid != null)
            {
                Destination = dataByid.Destination;
                CoverUrl = dataByid.CoverUrl;
                CardUrl = dataByid.CardUrl;
                VisaType = dataByid.VisaType;
                VisaMode = dataByid.VisaMode;
                EntryType = dataByid.EntryType;
                VisaValidity = dataByid.VisaValidity;
                ProcessingTime = dataByid.ProcessingTime;
                MaxiMumStay = dataByid.MaxiMumStay;
                Price = dataByid.Price;
                Requirements = dataByid.Requirements;
                Policy = dataByid.Policy;
            }
        }
    }
}
