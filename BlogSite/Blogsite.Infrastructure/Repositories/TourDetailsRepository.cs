using Blogsite.Infrastructure.DbContexts;
using Blogsite.Infrastructure.Entities;
using DevSkill.Data;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogsite.Infrastructure.Repositories
{
    public class TourDetailsRepository:Repository<TourDetails,int,ApplicationDbContext>,ITourDetailsRepository
    {
        public TourDetailsRepository(ApplicationDbContext dbContext):base(dbContext)
        {
                
        }
    }
}
