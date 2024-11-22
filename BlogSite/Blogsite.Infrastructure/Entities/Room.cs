using DevSkill.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogsite.Infrastructure.Entities
{
    public class Room:IEntity<int>
    {
        public int Id { get; set; } 
        public int RoomNumber {  get; set; }    
        public string? RoomType {  get; set; }   
        public decimal Price {  get; set; }
        public int? Capacity { get; set; }
        public string? RoomFacilities {  get; set; } 
        public string? Policies {  get; set; }   
        public string? RoomPhUrl {  get; set; }
        public  Hotel? Hotel { get; set; }   
        public int HotelId {  get; set; }  
        public ICollection<HotelBooking>? HotelBookings { get; set; } = new List<HotelBooking>();

    }
}
