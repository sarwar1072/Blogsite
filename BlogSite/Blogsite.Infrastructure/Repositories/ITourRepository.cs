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
    public interface ITourRepository:IRepository<Tour,int,ApplicationDbContext>
    {
         Tour Gettour(Expression<Func<Tour, bool>> filter = null,
                                Func<IQueryable<Tour>, IIncludableQueryable<Tour, object>> include = null,
                                bool isTrackingOff = false);
        Tour GetFirstOrDefault(Expression<Func<Tour, bool>> filter = null, string? includeProperties = null);
    }
}
