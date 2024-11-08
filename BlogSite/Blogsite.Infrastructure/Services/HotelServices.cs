using Blogsite.Infrastructure.Entities;
using Blogsite.Infrastructure.UOWork;
using Blogsite.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogsite.Infrastructure.Services
{
    public class HotelServices : IHotelServices
    {
        private IProjectUnitOfWork _unitOfWork;
        public HotelServices(IProjectUnitOfWork projectUnitOf)
        {
            _unitOfWork = projectUnitOf;
        }
        public void AddHotel(Hotel hotel)
        {
            if (hotel == null)
                throw new InvalidOperationException("hotel can not be null");

            var name=_unitOfWork.HotelRepository.GetCount(x=> x.Name == hotel.Name);

            if (name != 0)
                throw new DuplicateException("hotel name can be same");

            _unitOfWork.HotelRepository.Add(hotel);
            _unitOfWork.Save();

        }

    }
}
