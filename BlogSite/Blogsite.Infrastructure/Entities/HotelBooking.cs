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
        public int NumberOfGuests { get; set; } // Number of Guests
        public bool AirportTransfer { get; set; }
        public bool ExtraBed { get; set; }
        public bool RoomOnHigherFloor { get; set; }
        public bool DecorationsInRoom { get; set; }
        public string? BedType { get; set; } // Radio button value
        public string? RoomPreference { get; set; } // Radio button value
        public string? NoteToProperty { get; set; } // Textarea
        public int? RoomId { get; set; }
        public Room? Room { get; set; }
        public Guid UserId { get; set; }
        public int? HotelId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
    }
}
