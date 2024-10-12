using Blogsite.Infrastructure.Entities;
using Blogsite.Infrastructure.Entities.Membership;
using Blogsite.Infrastructure.Seeds;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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
        }

        public DbSet<ApplicationUser>? ApplicationUsers { get; set; }
        public DbSet<Booking>? Bookings { get; set; }
        public DbSet<Flight>? Flights { get; set; }
        public DbSet<Hotel>? Hotels { get; set; }
        public DbSet<Images>? Images { get; set; }
        public DbSet<Payment>? Payments { get; set; }  
        public DbSet<Tour>? Tours { get; set; }
    }
}
