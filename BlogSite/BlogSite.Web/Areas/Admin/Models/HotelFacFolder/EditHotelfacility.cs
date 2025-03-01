using Blogsite.Infrastructure.Entities;
using Blogsite.Infrastructure.Services;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Options;

namespace BlogSite.Web.Areas.Admin.Models.HotelFacFolder
{
    public class EditHotelfacility:HotelfacilityModel
    {
        public int Id { get; set; }
        public string? BusinessFacilities { get; set; }
        public string? FitnessFacilities { get; set; }
        public string? FoodFacilities { get; set; }
        public string? General { get; set; }
        public string? IndoorFacitilies { get; set; }
        public string? Parking { get; set; }
        public string? Policies { get; set; }
        public int? HotelId { get; set; }
        public Hotel? Hotel { get; set; }

        public EditHotelfacility(IHttpContextAccessor httpContext, IHotelfacilityServices hotelfacility) : base(httpContext, hotelfacility)
        {
        }
        public EditHotelfacility() { }

        public void EditDetails()
        {
            var model = new HotelFacilities()
            {
                Id = Id,
                FoodFacilities = FoodFacilities,
                General = General,
                IndoorFacitilies = IndoorFacitilies,
                Parking = Parking,
                Policies = Policies,
                HotelId = HotelId,               
            };
            _hotelfacility.EditHotelfacility(model);
        }
        public void Load(int id)
        {
            var dataByid = _hotelfacility.GetByid(id);
            if (dataByid != null)
            {
                Id = dataByid.Id;
                FoodFacilities = dataByid.FoodFacilities;
                General = dataByid.General;
                IndoorFacitilies = dataByid.IndoorFacitilies;
                Parking = dataByid.Parking;
                Policies = dataByid.Policies;
            }
        }
        public void RemoveHotelfasci(int id)
        {
            _hotelfacility.DeletehotelFacility(id);
        }
    }
}
