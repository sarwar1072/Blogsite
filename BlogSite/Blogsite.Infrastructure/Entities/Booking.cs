using DevSkill.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogsite.Infrastructure.Entities
{
    public class Booking:IEntity<int>
    {
        public int Id { get; set; }
        public Guid UserID { get; set; }
        public string? BookingType { get; set; } // e.g., "Flight", "Hotel", "Tour"
        public double TotalPrice { get; set; }
        public DateTime BookingDate { get; set; }

        // Relationship to the payment
        public Payment? Payment { get; set; }
    }
}
