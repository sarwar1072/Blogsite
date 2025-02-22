using Blogsite.Infrastructure.Entities;
using Blogsite.Infrastructure.Services;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BlogSite.Web.Areas.Admin.Models.VisaFolder
{
    public class CreateVisaModel:VisaModel
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
        public CreateVisaModel(IHttpContextAccessor httpContext,IVisaServices visaServices):base(httpContext, visaServices) { }
        
        public CreateVisaModel() { }

       
        public void AddVisa()
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
                ProcessingTime= ProcessingTime, 
                MaxiMumStay = MaxiMumStay,
                Price = Price,
                Requirements = Requirements,
                Policy = Policy,  
                
            };
            
            _visaServices.AddVisa(model);
        }
    }
}
