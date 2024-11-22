using DevSkill.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogsite.Infrastructure.Entities
{
    public class HotelBooking:IEntity<int>
    {
        public int Id { get; set; }

        public int? RoomId { get; set; }
        public Room? Room { get; set; } 
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
    }
}
