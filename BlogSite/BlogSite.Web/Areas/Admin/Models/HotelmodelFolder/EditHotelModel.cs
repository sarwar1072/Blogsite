using Blogsite.Infrastructure.Entities;
using Blogsite.Infrastructure.Services;

namespace BlogSite.Web.Areas.Admin.Models.HotelmodelFolder
{
    public class EditHotelModel:HotelModel
    {
        public EditHotelModel(IHttpContextAccessor httpContext, IHotelServices hotelServices) : base(httpContext, hotelServices) { }

        public EditHotelModel() { }
        public int Id { get; set; } 
        public string? Name { get; set; }
        public string? Location { get; set; }
        public string? HotelUrl { get; set; }
        public IFormFile formFile { get; set; }
        public double PricePerNight { get; set; }
        public int AvailableRooms { get; set; }

        public void editHotel()
        {
            var model = new Hotel()
            {
                Id = Id,
                Name = Name,
                Location = Location,
                HotelUrl = HotelUrl,
                PricePerNight = PricePerNight,
                AvailableRooms = AvailableRooms,
            };
            
            _hotelServices.EditHotel(model);
        }
        public void Load(int id)
        {
            var dataByid = _hotelServices.GetByid(id);
            if (dataByid != null)
            {
                Id = dataByid.Id;
                Name = dataByid.Name;
                Location = dataByid.Location;
                HotelUrl = dataByid.HotelUrl;
                PricePerNight = dataByid.PricePerNight;
                AvailableRooms = dataByid.AvailableRooms;             
            }
        }
        public void DeleteHotel(int id)
        {
            _hotelServices.Deletehotel(id); 
        }

    }
}
