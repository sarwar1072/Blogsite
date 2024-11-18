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
    public interface IHotelRepository:IRepository<Hotel,int,ApplicationDbContext>
    {
          Hotel GetHotelRepo(Expression<Func<Hotel, bool>> filter = null,
                                Func<IQueryable<Hotel>, IIncludableQueryable<Hotel, object>> include = null,
                                bool isTrackingOff = false);
        Hotel GetDynamic(Expression<Func<Hotel, bool>> filter = null,
       Func<IQueryable<Hotel>, IIncludableQueryable<Hotel, object>> include = null);
    }
}
