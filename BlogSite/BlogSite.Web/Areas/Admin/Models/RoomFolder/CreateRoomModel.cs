using Blogsite.Infrastructure.Entities;
using Blogsite.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.CodeDom;

namespace BlogSite.Web.Areas.Admin.Models.RoomFolder
{
    public class CreateRoomModel : RoomModel
    {
        public CreateRoomModel(IHttpContextAccessor httpContext,IRoomServices services) : base(httpContext, services) { }      
        public CreateRoomModel() { }
        public int RoomNumber { get; set; }
        public string? RoomType { get; set; }
        public decimal Price { get; set; }
        public int Capacity { get; set; }
        public string? RoomPhUrl { get; set; }
        public IFormFile formFile { get; set; } 
        //public Hotel? Hotel { get; set; }
        public int HotelId { get; set; }

        public void addRoom()
        {
            var model = new Room()
            {
                RoomNumber = RoomNumber,    
                RoomType = RoomType,
                Price = Price,
                Capacity = Capacity,
                RoomPhUrl = RoomPhUrl,
                HotelId = HotelId,    
            };           
            _services.AddRoom(model);
        }
        public IList<SelectListItem> ListOfHotelName()
        {
            var listOfHotel = new List<SelectListItem>();
            foreach (var item in _services.GetAll())
            {
                var addItem = new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                };
                listOfHotel.Add(addItem);
            }
            return listOfHotel;
        }


    }

}
