using Autofac;
using Blogsite.Infrastructure.Entities;
using Blogsite.Infrastructure.Services;
using BlogSite.Web.Areas.Admin.Models;
using DevSkill.Data;
using Microsoft.CodeAnalysis;
using System.CodeDom;

namespace BlogSite.Web.Models.HotelViewM
{
    public class HotelModelView:AdminBaseModel
    {
        protected IHotelServices _hotelServices;
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }
        public string? HotelUrl { get; set; }
        public IFormFile formFile { get; set; }
        public double PricePerNight { get; set; }
        public int night {  get; set; } 
        public int AvailableRooms { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int NumberOfGuests {  get; set; }    
        public IList<Hotel> HotelList { set; get; }
        public IList<Room> rooms { set; get; }
        public int roomId {  get; set; }    
        public HotelFacilities hotelFacilities { get; set; }    
        public IList<Images> images { set; get; }
        public HotelModelView(IHttpContextAccessor contextAccessor,IHotelServices hotelServices):base(contextAccessor)
        {
                _hotelServices = hotelServices; 
        }
        public HotelModelView() { }
        public override void ResolveDependency(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
            _hotelServices = _lifetimeScope.Resolve<IHotelServices>();
            base.ResolveDependency(lifetimeScope);
        }
        public void ListOfHotelWithRoom(string location, DateTime checkInDate, DateTime checkOutDate,int numberOfGuests)
        {
            var data = _hotelServices.SearchedHotelList(location, checkInDate, checkOutDate, numberOfGuests);

            HotelList = new List<Hotel>();
            foreach (var hotel in data)
            {
                HotelList.Add(new Hotel
                {
                    Id = hotel.Id,  
                    Name = hotel.Name,
                    Location = hotel.Location,
                    HotelUrl = hotel.HotelUrl,
                    AvailableRooms = hotel.AvailableRooms,
                    PricePerNight = hotel.PricePerNight,
                });
            }

        }
        public void ListOfHotelWithRoomDetails(int id,string location, DateTime checkInDate, DateTime checkOutDate, int numberOfGuests)
        {
            var data = _hotelServices.SearchedRoomListWithHotel(id,location, checkInDate, checkOutDate, numberOfGuests);

           if (data != null)
            {
                Id= data.Id;
                Location= data.Location;    
                Name= data.Name;    
                PricePerNight= data.PricePerNight;
                AvailableRooms= data.AvailableRooms;
                images=new List<Images>();   
                hotelFacilities=new HotelFacilities();
                if(data.HotelFacilities != null)
                {
                    hotelFacilities.BusinessFacilities = data.HotelFacilities.BusinessFacilities;
                    hotelFacilities.FitnessFacilities = data.HotelFacilities.FitnessFacilities;
                    hotelFacilities.FoodFacilities = data.HotelFacilities.FoodFacilities;
                    hotelFacilities.General = data.HotelFacilities.General;
                    hotelFacilities.IndoorFacitilies = data.HotelFacilities.IndoorFacitilies;
                    hotelFacilities.Parking = data.HotelFacilities.Parking;
                    hotelFacilities.Policies = data.HotelFacilities.Policies;

                }
                if (data.Images != null)
                {
                    foreach (var item in data.Images)
                    {
                        images.Add(new Images
                        {
                            ImageUrl = item.ImageUrl,
                            AlternativeText=item.AlternativeText,
                        });
                    }
                }
                rooms=new List<Room>(); 
                if(data.Rooms != null)
                {
                    foreach(var item in data.Rooms)
                    {
                        rooms.Add(new Room
                        {
                            Id = item.Id,   
                            RoomNumber = item.RoomNumber,   
                            RoomType = item.RoomType,   
                            Price = item.Price, 
                            Capacity = item.Capacity,
                            RoomPhUrl = item.RoomPhUrl, 
                        });
                    }
                }
            }        
        }
        public IList<Hotel> ListOfHotel()
        {
            var entity = _hotelServices.GetAlHotesls();
            HotelList = new List<Hotel>();
            foreach (var hotel in entity)
            {
                HotelList.Add(new Hotel
                {
                    Id=hotel.Id,
                    Name = hotel.Name,
                    Location = hotel.Location,
                    HotelUrl = hotel.HotelUrl,
                    PricePerNight = hotel.PricePerNight,
                });
            }
            return HotelList;
        }


    }
}
