using Autofac;
using Blogsite.Infrastructure.Entities;
using Blogsite.Infrastructure.Services;
using BlogSite.Web.Areas.Admin.Models;
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
        public int AvailableRooms { get; set; }
        public IList<Hotel> HotelList { set; get; }

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
        public IList<Hotel> ListOfHotel()
        {
            var entity = _hotelServices.GetAlHotesls();
            HotelList = new List<Hotel>();
            foreach (var hotel in entity)
            {
                HotelList.Add(new Hotel
                {
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
