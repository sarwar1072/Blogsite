using Blogsite.Infrastructure.Entities;
using Blogsite.Infrastructure.Exceptions;
using Blogsite.Infrastructure.UOWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogsite.Infrastructure.Services
{
    public class HotelfacilityServices:IHotelfacilityServices
    {
        private IProjectUnitOfWork _unitOfWork;
        public HotelfacilityServices(IProjectUnitOfWork projectUnitOfWork)
        {
                _unitOfWork = projectUnitOfWork;
        }
        public void Addfacility(HotelFacilities hotelfacility)
        {
            if (hotelfacility == null)
                throw new InvalidOperationException("hotelfacility can not be null");       

            _unitOfWork.HotelFacilitiesRepositories.Add(hotelfacility);
            _unitOfWork.Save();
        }
        public IList<Hotel> GetAlHotesls()
        {
            return _unitOfWork.HotelRepository.GetAll();
        }
        public IList<string> GetAllHoteslsWithoutLimit()
        {
            var entity = _unitOfWork.HotelRepository.GetAll();

            // Select distinct locations from the entity list
            var name = entity
                .Select(c => c.Name)
                .Where(location => !string.IsNullOrEmpty(location)) // Optional: Filter out null or empty locations
                .Distinct()
                .ToList();

            return name;
        }
        public void EditHotelfacility(HotelFacilities hotel)
        {
            if (hotel is null)
            {
                throw new InvalidOperationException("Hotelfacility  can not be null");
            }

            var entity = _unitOfWork.HotelFacilitiesRepositories.GetById(hotel.Id);

            if (entity == null)
                throw new InvalidOperationException("Hotelfacility can not be null");

            // entity.Id = tour.Id;
            entity.BusinessFacilities = hotel.BusinessFacilities;
            entity.FitnessFacilities = hotel.FitnessFacilities;
            entity.FoodFacilities = hotel.FoodFacilities;
            entity.General = hotel.General;
            entity.IndoorFacitilies = hotel.IndoorFacitilies;
            entity.Parking= hotel.Parking;
            entity.Policies = hotel.Policies;   
            _unitOfWork.HotelFacilitiesRepositories.Edit(entity);
            _unitOfWork.Save();
        }
        public HotelFacilities GetByid(int id)
        {
            var entity = _unitOfWork.HotelFacilitiesRepositories.GetById(id);
            return entity;
        }
        public void DeletehotelFacility(int id)
        {
            var entity = _unitOfWork.HotelFacilitiesRepositories.GetById(id);
            if (entity == null)
            {
                throw new InvalidOperationException("Hotelfacilities is not found");
            }
            _unitOfWork.HotelFacilitiesRepositories.Remove(entity);
            _unitOfWork.Save();
        }
               
        public (IList<HotelFacilities> hotels, int total, int totalDisplay) GetHotelfacilityList(int pageindex, int pagesize, string searchText, string orderBy)
        {
            (IList<HotelFacilities> data, int total, int totalDisplay) result = (null, 0, 0);
            if (string.IsNullOrWhiteSpace(searchText))
            {
                result = _unitOfWork.HotelFacilitiesRepositories.GetDynamic(null, null, null, pageindex, pagesize, true);
            }
            else
            {
                result = _unitOfWork.HotelFacilitiesRepositories.GetDynamic(x => x.BusinessFacilities.ToLower() == searchText.ToLower()
               , null, null, pageindex, pagesize, true);
            }
            return (result.data, result.total, result.totalDisplay);
        }

    }
}
