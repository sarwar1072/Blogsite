using Blogsite.Infrastructure.Entities;
using Blogsite.Infrastructure.Exceptions;
using Blogsite.Infrastructure.UOWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogsite.Infrastructure.Services
{
    public class TravelServices: ITravelServices
    {
        private IProjectUnitOfWork _projectUnitOfWork;
        public TravelServices(IProjectUnitOfWork projectUnitOfWork)
        {
            _projectUnitOfWork = projectUnitOfWork;
        }

        public void AddTraveller( Traveller traveller)
        {
            if (traveller is null)
            {
                throw new InvalidOperationException("Traveller can not be null");
            }
            var tourCount = _projectUnitOfWork.TravellerRepository.GetCount(c => c.Name == traveller.Name);

            if (tourCount > 0)
            {
                throw new DuplicateException("Same name exist");
            }
            _projectUnitOfWork.TravellerRepository.Add(traveller);
            _projectUnitOfWork.Save();
        }

        //public void EditTraveller(Traveller traveller)
        //{
        //    if ( traveller is null)
        //    {
        //        throw new InvalidOperationException("Traveller can not be null");
        //    }

        //    var entity = _projectUnitOfWork.VisaRepository.GetById(visa.Id);

        //    if (entity == null)
        //        throw new InvalidOperationException("Visa can not be null");

            

        //    _projectUnitOfWork.VisaRepository.Edit(entity);
        //    _projectUnitOfWork.Save();
        //}
        public Traveller GetByid(int id)
        {
            var entity = _projectUnitOfWork.TravellerRepository.GetById(id);
            return entity;
        }

        public IList<Traveller> GetByUserId(Guid id)
        {
            var list = _projectUnitOfWork.TravellerRepository.Get(x => x.UserId == id, null,
                            null, false);

            return list; 
        }

    }
}
