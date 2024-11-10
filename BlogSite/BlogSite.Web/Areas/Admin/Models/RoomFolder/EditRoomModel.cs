using Blogsite.Infrastructure.Entities;
using Blogsite.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogSite.Web.Areas.Admin.Models.RoomFolder
{
    public class EditRoomModel:RoomModel
    {
        public EditRoomModel(IHttpContextAccessor httpContext, IRoomServices services) : base(httpContext, services) { }
        public EditRoomModel() { }
        public int Id { get; set; } 
        public int RoomNumber { get; set; }
        public string? RoomType { get; set; }
        public decimal Price { get; set; }
        public string? RoomPhUrl { get; set; }
        public IFormFile formFile { get; set; }
        public Hotel? Hotel { get; set; }
        public int HotelId { get; set; }

        public void EditRoom()
        {
            var model = new Room()
            {
                Id = Id,    
                RoomNumber = RoomNumber,
                RoomType = RoomType,
                Price = Price,
                RoomPhUrl = RoomPhUrl,
            };
            _services.EditRoom(model);
        }
        public void Load(int id)
        {
            var dataByid = _services.GetById(id);
            if (dataByid != null)
            {
                Id = dataByid.Id;
                RoomNumber = dataByid.RoomNumber;
                RoomType = dataByid.RoomType;
                Price = dataByid.Price;
                RoomPhUrl = dataByid.RoomPhUrl;               
            }
        }
        public void RemoveRoom(int id)
        {
            _services.DeleteRoom(id);
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
