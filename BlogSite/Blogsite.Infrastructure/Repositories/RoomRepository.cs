using Blogsite.Infrastructure.DbContexts;
using Blogsite.Infrastructure.Entities;
using DevSkill.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogsite.Infrastructure.Repositories
{
    public class RoomRepository:Repository<Room ,int,ApplicationDbContext>,IRoomRepository
    {


        public RoomRepository(ApplicationDbContext dbContext):base(dbContext) 
        {
                
        }
    }
}
