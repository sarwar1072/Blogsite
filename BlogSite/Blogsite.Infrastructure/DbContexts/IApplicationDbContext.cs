﻿using Blogsite.Infrastructure.Entities;
using Blogsite.Infrastructure.Entities.Membership;
using Microsoft.EntityFrameworkCore;

namespace Blogsite.Infrastructure.DbContexts
{
    public interface IApplicationDbContext
    {
         DbSet<ApplicationUser>? ApplicationUsers { get; set; }
         DbSet<Booking>? Bookings { get; set; }
         DbSet<Visa>? Visas { get; set; }
         DbSet<Hotel>? Hotels { get; set; }
         DbSet<Images>? Images { get; set; }
         DbSet<Payment>? Payments { get; set; }
         DbSet<Tour>? Tours { get; set; }
         DbSet<TourDetails>? ToursDetails { get; set; }
         DbSet<ConsultationForm>? ConsultationForms { get; set; }
         DbSet<Room>? Rooms { get; set; }
         DbSet<HotelBooking>? HotelBookings { get; set; }
         DbSet<HotelFacilities>? HotelFacilities { get; }
         DbSet<UserForm>? UserForms { get; set; }
         DbSet<Traveller>? Travellers { get; set; }



    }
}
