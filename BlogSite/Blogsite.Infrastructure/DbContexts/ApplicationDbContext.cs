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
            //builder.Entity<ApplicationUser>()
            //    .HasData(ApplicationUserSeed.Users);

            //builder.Entity<Role>()
            //    .HasData(RoleSeed.Roles);

            //builder.Entity<UserRole>()
            //    .HasData(UserRoleSeed.UserRole);

            base.OnModelCreating(builder);
            #endregion
        }

        public DbSet<ApplicationUser>? ApplicationUsers { get; set; }
        public DbSet<Post>? Posts { get; set; }
        //public DbSet<Answer>? Answers { get; set; }
        //public DbSet<Comment>? Comments { get; set; }
        //public DbSet<Tag>? Tags { get; set; }
        //public DbSet<Vote> Votes { get; set; }
    }
}
