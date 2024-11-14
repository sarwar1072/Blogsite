using Blogsite.Infrastructure.Entities;
using Blogsite.Infrastructure.Entities.Membership;
using Blogsite.Infrastructure.Seeds;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Blogsite.Infrastructure.DbContexts
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, Role, Guid,
        UserClaim, UserRole, UserLogin, RoleClaim, UserToken>, IApplicationDbContext
    {
        private readonly string? _connectionString;
        private readonly string? _migrationAssemblyName;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public ApplicationDbContext(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(
                    _connectionString!,
                    m => m.MigrationsAssembly(_migrationAssemblyName));       
            }

            base.OnConfiguring(dbContextOptionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            #region Seed
            builder.Entity<ApplicationUser>()
                .HasData(ApplicationUserSeed.Users);

            builder.Entity<Role>()
                .HasData(RoleSeed.Roles);

            builder.Entity<UserRole>()
                .HasData(UserRoleSeed.UserRole);

            base.OnModelCreating(builder);
            #endregion

                builder.Entity<Tour>()
                    .HasMany(t => t.Images)
                    .WithOne(i => i.Tour)
                    .HasForeignKey(i => i.TourId)
                    .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Hotel>()
                    .HasMany(t => t.Images)
                    .WithOne(i => i.Hotel)
                    .HasForeignKey(i => i.HotelId)
                    .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Tour>()
                   .HasOne(t => t.TourDetails)
                   .WithMany(td => td.Tours)
                   .HasForeignKey(t => t.TourDetailsId)
                    .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Booking>()
                    .HasOne(b => b.Payment)  // A Booking has one Payment
                    .WithOne(p => p.Booking)  // A Payment is associated with one Booking
                    .HasForeignKey<Payment>(p => p.BookingID)  // Foreign key in Payment
                    .OnDelete(DeleteBehavior.Cascade);  // Optional: Cascade delete

            builder.Entity<Hotel>()
                   .HasMany(t => t.Rooms)
                   .WithOne(i => i.Hotel)
                   .HasForeignKey(i => i.HotelId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Room>()
                    .HasMany(t=>t.HotelBookings)
                    .WithOne(i=> i.Room)
                    .HasForeignKey(i => i.RoomId)
                   .OnDelete(DeleteBehavior.Cascade);

        }

        public DbSet<ApplicationUser>? ApplicationUsers { get; set; }
        public DbSet<Booking>? Bookings { get; set; }
        public DbSet<Flight>? Flights { get; set; }
        public DbSet<Hotel>? Hotels { get; set; }
        public DbSet<Images>? Images { get; set; }
        public DbSet<Payment>? Payments { get; set; }  
        public DbSet<Tour>? Tours { get; set; }
        public DbSet<TourDetails>? ToursDetails { get; set;}
        public DbSet<ConsultationForm>?  ConsultationForms { get; set; }  
        public DbSet<Room>? Rooms { get; set; }
        public DbSet<HotelBooking>? HotelBookings { get; set;}
    }
}
