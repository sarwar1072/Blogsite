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
    public interface IRoomRepository:IRepository<Room,int,ApplicationDbContext>
    {
        Room GetDynamic(Expression<Func<Room, bool>> filter = null,
      Func<IQueryable<Room>, IIncludableQueryable<Room, object>> include = null);
    }
}
