using Blogsite.Infrastructure.DbContexts;
using Blogsite.Infrastructure.Entities;
using DevSkill.Data;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blogsite.Infrastructure.Repositories
{
    public  class HotelRepository:Repository<Hotel,int,ApplicationDbContext>, IHotelRepository  
    {
        public HotelRepository(ApplicationDbContext dbContext):base(dbContext) 
        {
            
        }
        public virtual Hotel GetDynamic(Expression<Func<Hotel, bool>> filter = null, 
          Func<IQueryable<Hotel>, IIncludableQueryable<Hotel, object>> include = null)
        {
            IQueryable<Hotel> queryable = _dbSet;
            if (filter != null)
            {
                queryable = queryable.Where(filter);
            }

            if (include != null)
            {
                queryable = include(queryable);
            }
                   
            return queryable.FirstOrDefault();
        }
       
        public virtual Hotel GetHotelRepo(Expression<Func<Hotel, bool>> filter = null,
                                Func<IQueryable<Hotel>, IIncludableQueryable<Hotel, object>> include = null,
                                bool isTrackingOff = false)
        {
            // Start with the base query on the DbSet
            IQueryable<Hotel> queryable = _dbSet;

            // Apply filtering if provided
            if (filter != null)
            {
                queryable = queryable.Where(filter);
            }

            // Apply eager loading for related entities if `include` is provided
            if (include != null)
            {
                queryable = include(queryable);
            }

            // Disable tracking if specified
            if (isTrackingOff)
            {
                queryable = queryable.AsNoTracking();
            }

            // Fetch the first or default entity matching the filter, including any related entities
            return queryable.FirstOrDefault(); // Adjust this as per your exact needs (e.g., SingleOrDefault)
        }

    }
}
