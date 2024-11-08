using DevSkill.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogsite.Infrastructure.Entities
{
    public class Hotel:IEntity<int>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }
        public string? HotelUrl {  get; set; }    
        public double PricePerNight { get; set; }
        public int AvailableRooms { get; set; }
        public ICollection<Room>? Rooms { get; set; }
        public ICollection<Images>? Images { get; set; }
    }
}
