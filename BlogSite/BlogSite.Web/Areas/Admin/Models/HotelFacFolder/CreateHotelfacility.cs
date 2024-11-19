using Autofac;
using Blogsite.Infrastructure.Entities;
using Blogsite.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogSite.Web.Areas.Admin.Models.HotelFacFolder
{
    public class CreateHotelfacility: HotelfacilityModel
    {
        public CreateHotelfacility(IHttpContextAccessor httpContext, IHotelfacilityServices hotelfacility) : base(httpContext, hotelfacility) { }
       
        public CreateHotelfacility() { }
        
        public string? BusinessFacilities { get; set; }
        public string? FitnessFacilities { get; set; }
        public string? FoodFacilities { get; set; }
        public string? General { get; set; }
        public string? IndoorFacitilies { get; set; }
        public string? Parking { get; set; }
        public string? Policies { get; set; }
        public int? HotelId { get; set; }
        public Hotel? Hotel { get; set; }

        public void AddHotelFacility()
        {
            var model = new HotelFacilities()
            {
                BusinessFacilities = BusinessFacilities,
                FitnessFacilities = FitnessFacilities,
                FoodFacilities = FoodFacilities,
                General = General,
                IndoorFacitilies = IndoorFacitilies,
                Parking = Parking,
                Policies = Policies,
                HotelId = HotelId   
            };
           
            _hotelfacility.Addfacility(model);
        }
        public IList<SelectListItem> ListOfHotel()
        {
            var listOftour = new List<SelectListItem>();
            foreach (var item in _hotelfacility.GetAlHotesls())
            {
                var addItem = new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                };
                listOftour.Add(addItem);
            }
            return listOftour;
        }


    }
}
