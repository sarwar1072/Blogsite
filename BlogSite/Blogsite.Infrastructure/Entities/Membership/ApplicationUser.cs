using Microsoft.AspNetCore.Identity;

namespace Blogsite.Infrastructure.Entities.Membership
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string? Name { get; set; }
        //public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Phone { get; set; }
        public string? Role { get; set; }  // e.g., "Traveler", "Admin"

        // Navigation property to link to the bookings
        public List<Booking>? Bookings { get; set; }
    }
}
