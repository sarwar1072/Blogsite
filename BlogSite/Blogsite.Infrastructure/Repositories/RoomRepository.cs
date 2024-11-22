using Blogsite.Infrastructure.DbContexts;
using Blogsite.Infrastructure.Entities;
using DevSkill.Data;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blogsite.Infrastructure.Repositories
{
    public class RoomRepository:Repository<Room ,int,ApplicationDbContext>,IRoomRepository
    {


        public RoomRepository(ApplicationDbContext dbContext):base(dbContext) 
        {
                
        }
        public virtual Room GetDynamic(Expression<Func<Room, bool>> filter = null,
          Func<IQueryable<Room>, IIncludableQueryable<Room, object>> include = null)
        {
            IQueryable<Room> queryable = _dbSet;
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
    }
}
