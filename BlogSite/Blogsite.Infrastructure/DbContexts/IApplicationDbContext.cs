using Blogsite.Infrastructure.Entities;
using Blogsite.Infrastructure.Entities.Membership;
using Microsoft.EntityFrameworkCore;

namespace Blogsite.Infrastructure.DbContexts
{
    public interface IApplicationDbContext
    {
         DbSet<ApplicationUser>? ApplicationUsers { get; set; }
         DbSet<Booking>? Bookings { get; set; }
         DbSet<Flight>? Flights { get; set; }
         DbSet<Hotel>? Hotels { get; set; }
         DbSet<Images>? Images { get; set; }
         DbSet<Payment>? Payments { get; set; }
         DbSet<Tour>? Tours { get; set; }
         DbSet<TourDetails>? ToursDetails { get; set; }
         DbSet<ConsultationForm>? ConsultationForms { get; set; }

    }
}
