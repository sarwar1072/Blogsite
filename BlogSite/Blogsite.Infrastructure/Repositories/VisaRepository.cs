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
    public class VisaRepository:Repository<Visa,int,ApplicationDbContext>, IVisaRepository
    {
        public VisaRepository(ApplicationDbContext dbContext):base(dbContext) { }
        
    }
}
