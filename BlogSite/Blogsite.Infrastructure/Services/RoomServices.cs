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



    }
}
