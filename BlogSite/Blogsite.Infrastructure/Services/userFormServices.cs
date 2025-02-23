using Blogsite.Infrastructure.Entities;
using Blogsite.Infrastructure.UOWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogsite.Infrastructure.Services
{
    public class userFormServices:IuserFormServices
    {
        private IProjectUnitOfWork _projectUnitOfWork;

        public userFormServices(IProjectUnitOfWork projectUnitOfWork)
        {
            _projectUnitOfWork = projectUnitOfWork;
        }
        public void AddUserForm(UserForm userForm)
        {
            _projectUnitOfWork.UserFormRepository.Add(userForm);
            _projectUnitOfWork.Save();
        }
    }
}
