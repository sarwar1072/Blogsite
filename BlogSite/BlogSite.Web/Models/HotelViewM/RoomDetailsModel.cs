using Autofac;
using Blogsite.Infrastructure.Entities;
using Blogsite.Infrastructure.Services;
using BlogSite.Web.Areas.Admin.Models;

namespace BlogSite.Web.Models.HotelViewM
{
    public class RoomDetailsModel:AdminBaseModel
    {
        protected IHotelServices _hotelServices;
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }
        public string? HotelUrl { get; set; }
        public double PricePerNight { get; set; }
        public int RoomNumber { get; set; }
        public string? RoomType { get; set; }
        public decimal Price { get; set; }
        public int? Capacity { get; set; }
        public string? RoomFacilities { get; set; }
        public string? Policies { get; set; }
        public string? RoomPhUrl { get; set; }
        public Hotel? Hotel { get; set; }
        public int HotelId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int NumberOfGuests { get; set; }
        public Hotel hotel { set; get; }
        public int nights {  get; set; }    
        public  HotelSearchFilter filter { get; set; }  
        public HotelFacilities hotelFacilities { get; set; }
        public RoomDetailsModel(IHttpContextAccessor contextAccessor, IHotelServices hotelServices) : base(contextAccessor)
        {
            _hotelServices = hotelServices;
        }
        public RoomDetailsModel() { }
        public override void ResolveDependency(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
            _hotelServices = _lifetimeScope.Resolve<IHotelServices>();
            base.ResolveDependency(lifetimeScope);
        }
        public void RoomDetails(int id,DateTime checkInDate,DateTime checkOutDate,int numberOfGuests)
        {
            var data=_hotelServices.GetRoomDetailsById(id); 
            if(data != null)
            {
                RoomType=data.RoomType; 
                Price=data.Price;
                RoomFacilities=data.RoomFacilities; 
                Policies=data.Policies;
                RoomPhUrl=data.RoomPhUrl;   
                hotel = new Hotel
                {
                    Name = data.Hotel.Name,
                    Location= data.Hotel.Location,  
                    HotelUrl = data.Hotel.HotelUrl,
                };
                filter=new HotelSearchFilter();
                filter.CheckInDate = checkInDate;
                filter.CheckOutDate = checkOutDate; 
                nights=(checkOutDate-checkInDate).Days;
                filter.NumberOfGuests = numberOfGuests;              
            }
        }

    }
}
