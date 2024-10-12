using Blogsite.Infrastructure.DbContexts;
using Blogsite.Infrastructure.Repositories;
using DevSkill.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogsite.Infrastructure.UOWork
{
    public class ProjectUnitOfWork:UnitOfWork,IProjectUnitOfWork
    {
        public ITourRepository TourRepository { get;private  set;}
        public ProjectUnitOfWork(ApplicationDbContext dbContext, ITourRepository tourRepository):base(dbContext)
        {
                TourRepository = tourRepository;
        }
    }
}
