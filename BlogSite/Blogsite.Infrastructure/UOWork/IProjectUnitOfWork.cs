using Blogsite.Infrastructure.Repositories;
using DevSkill.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogsite.Infrastructure.UOWork
{
    public interface IProjectUnitOfWork:IUnitOfWork
    {
         ITourRepository TourRepository { get; }
        ITourDetailsRepository TourDetailsRepository { get; }
         IConsultationFormRepository ConsultationFormRepository { get; }
        IHotelRepository HotelRepository { get; }
         IRoomRepository RoomRepository { get; }
         IHotelFacilitiesRepositories HotelFacilitiesRepositories { get; }
        IHotelBookingRepository HotelBookingRepository { get; }
         IVisaRepository VisaRepository { get;  }

    }
}
