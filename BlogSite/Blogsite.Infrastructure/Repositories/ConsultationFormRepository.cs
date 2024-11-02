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
    public class ConsultationFormRepository:Repository<ConsultationForm,int,ApplicationDbContext>, IConsultationFormRepository
    {
        public ConsultationFormRepository(ApplicationDbContext dbContext):base(dbContext) { }   
        
    }
}
