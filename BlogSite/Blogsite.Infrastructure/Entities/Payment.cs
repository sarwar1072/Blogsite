using DevSkill.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogsite.Infrastructure.Entities
{
    public class Payment:IEntity<int>
    {
        public int Id { get; set; }
        public int BookingID { get; set; }
        public double Amount { get; set; }
        public string? PaymentMethod { get; set; } // e.g., "CreditCard", "PayPal", etc.
        public string? PaymentStatus { get; set; } // e.g., "Completed", "Pending", etc.
    }
}
