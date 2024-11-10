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
    public class RoomServices:IRoomServices
    {
        private IProjectUnitOfWork _projectUnitOfWork;
        public RoomServices(IProjectUnitOfWork unitOfWork)
        {
                _projectUnitOfWork = unitOfWork;
        }
        public void AddRoom(Room room)
        {
            if(room== null)
            {
                throw new InvalidOperationException("room can not be null");
            }

            var count=_projectUnitOfWork.RoomRepository.GetCount(x=>room.RoomNumber == x.RoomNumber);   
            if(count!=0) {
               throw new DuplicateException("Same room number exist");
            }
            _projectUnitOfWork.RoomRepository.Add(room);
            _projectUnitOfWork.Save();
        }
        public void EditRoom(Room room)
        {
            if (room is null)
            {
                throw new InvalidOperationException("Question can not be null");
            }

            var entity = _projectUnitOfWork.RoomRepository.GetById(room.Id);

            if (entity == null)
                throw new InvalidOperationException("Question can not be null");

            entity.RoomNumber = room.RoomNumber;
            entity.RoomType = room.RoomType;
            entity.Price = room.Price;
            entity.RoomPhUrl = room.RoomPhUrl;
           
            _projectUnitOfWork.RoomRepository.Edit(entity);
            _projectUnitOfWork.Save();
        }
        public Room GetById(int id) { 
            return _projectUnitOfWork.RoomRepository.GetById(id);
        }
        public IList<Hotel> GetAll()
        {
            return _projectUnitOfWork.HotelRepository.GetAll();
        }
        public (IList<Room> rooms, int total, int totalDisplay) GetRoomList(int pageindex, int pagesize, string searchText, string orderBy)
        {
            (IList<Room> data, int total, int totalDisplay) result = (null, 0, 0);
            if (string.IsNullOrWhiteSpace(searchText))
            {
                result = _projectUnitOfWork.RoomRepository.GetDynamic(null, null, null, pageindex, pagesize, true);
            }
            else
            {
                result = _projectUnitOfWork.RoomRepository.GetDynamic(null, null, null, pageindex, pagesize, true);
            }
            return (result.data, result.total, result.totalDisplay);
        }
        public void DeleteRoom(int id)
        {
            var entity = _projectUnitOfWork.RoomRepository.GetById(id);
            if (entity == null)
            {
                throw new InvalidOperationException("Room is not found");
            }
            _projectUnitOfWork.RoomRepository.Remove(entity);
            _projectUnitOfWork.Save();
        }

    }
}
