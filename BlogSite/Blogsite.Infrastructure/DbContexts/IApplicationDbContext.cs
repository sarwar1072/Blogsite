using Blogsite.Infrastructure.Entities.Membership;
using Microsoft.EntityFrameworkCore;

namespace Blogsite.Infrastructure.DbContexts
{
    public interface IApplicationDbContext
    {
        DbSet<ApplicationUser>? ApplicationUsers { get; set; }
        //DbSet<Question>? Questions { get; set; }
        //DbSet<Answer>? Answers { get; set; }
        //DbSet<Comment>? Comments { get; set; }
        //DbSet<Tag>? Tags { get; set; }
        //DbSet<Vote>? Votes { get; set; }
    }
}
