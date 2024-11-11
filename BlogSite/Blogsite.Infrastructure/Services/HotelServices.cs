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
        public IList<Hotel> GetAlHotesls()
        {
            return _unitOfWork.HotelRepository.GetAll().Take(5).ToList();
        }
        public void EditHotel(Hotel hotel)
        {
            if (hotel is null)
            {
                throw new InvalidOperationException("Hotel  can not be null");
            }

            var entity = _unitOfWork.HotelRepository.GetById(hotel.Id);

            if (entity == null)
                throw new InvalidOperationException("Hotel can not be null");

            // entity.Id = tour.Id;
            entity.Name = hotel.Name;
            entity.Location = hotel.Location;
            entity.HotelUrl = hotel.HotelUrl;
            entity.PricePerNight = hotel.PricePerNight;
            entity.AvailableRooms =hotel.AvailableRooms;
            
            _unitOfWork.HotelRepository.Edit(entity);
            _unitOfWork.Save();
        }
        public Hotel GetByid(int id)
        {
            var entity = _unitOfWork.HotelRepository.GetById(id);
            return entity;
        }
        public void Deletehotel(int id)
        {
            var entity = _unitOfWork.HotelRepository.GetById(id);
            if (entity == null)
            {
                throw new InvalidOperationException("Hotel is not found");
            }
            _unitOfWork.HotelRepository.Remove(entity);
            _unitOfWork.Save();
        }

        public (IList<Hotel> hotels, int total, int totalDisplay) GetHotelList(int pageindex, int pagesize, string searchText, string orderBy)
        {
            (IList<Hotel> data, int total, int totalDisplay) result = (null, 0, 0);
            if (string.IsNullOrWhiteSpace(searchText))
            {
                result = _unitOfWork.HotelRepository.GetDynamic(null, null, null, pageindex, pagesize, true);
            }
            else
            {
                result = _unitOfWork.HotelRepository.GetDynamic(x => x.Name.ToLower() == searchText.ToLower()
                || x.Location.ToLower() == searchText.ToLower(), null, null, pageindex, pagesize, true);
            }
            return (result.data, result.total, result.totalDisplay);
        }

    }
}
