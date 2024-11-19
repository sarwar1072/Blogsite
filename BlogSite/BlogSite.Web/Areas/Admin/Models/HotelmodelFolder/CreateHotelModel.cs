using Blogsite.Infrastructure.Entities;
using Blogsite.Infrastructure.Services;
using System.CodeDom;

namespace BlogSite.Web.Areas.Admin.Models.HotelmodelFolder
{
    public class CreateHotelModel:HotelModel
    {
        public CreateHotelModel(IHttpContextAccessor httpContext,IHotelServices hotelServices) : base(httpContext, hotelServices) { }
        
        public CreateHotelModel() { }
        
        public string? Name { get; set; }
        public string? Location { get; set; }
        public string? HotelUrl { get; set; }
        public IFormFile formFile { get; set; } 
        public double PricePerNight { get; set; }
        public int AvailableRooms { get; set; }
        public ICollection<Room>? Rooms { get; set; }
        public ICollection<Images>? Images { get; set; }
        public IFormFileCollection ListofImages { get; set; }
        public List<string>? UrlList { get; set; }

        public void addHotel()
        {
            var model = new Hotel()
            {
                Name = Name,    
                Location = Location,
                HotelUrl = HotelUrl,
                PricePerNight = PricePerNight,
                AvailableRooms = AvailableRooms,  
            };
            model.Images = new List<Images>();
            if (UrlList != null)
            {
                for (int i = 0; i < UrlList.Count; i++)
                {
                    model.Images.Add(new Images
                    {
                        ImageUrl = UrlList[i],
                        AlternativeText = $"{model.Name} image",
                    });

                }
            }
            _hotelServices.AddHotel(model);
        }



    }

}
