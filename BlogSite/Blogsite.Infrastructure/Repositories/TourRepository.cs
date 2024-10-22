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
    public class TourRepository:Repository<Tour,int,ApplicationDbContext>,ITourRepository
    {
        public TourRepository(ApplicationDbContext dbContext):base(dbContext)
        {
                
        }

        public virtual Tour Gettour(Expression<Func<Tour, bool>> filter = null,
                                Func<IQueryable<Tour>, IIncludableQueryable<Tour, object>> include = null,
                                bool isTrackingOff = false)
        {
            // Start with the base query on the DbSet
            IQueryable<Tour> queryable = _dbSet;

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

        public Tour GetFirstOrDefault(Expression<Func<Tour, bool>> filter = null, string? includeProperties = null)
        {
            IQueryable<Tour> query = _dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.FirstOrDefault();
        }


    }
}
