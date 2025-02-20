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
        public ITourDetailsRepository TourDetailsRepository { get;private set;}
        public IConsultationFormRepository ConsultationFormRepository { get;private set;}
        public IHotelRepository HotelRepository { get;private set;}
        public IRoomRepository RoomRepository { get;private set;}  
        public IHotelBookingRepository HotelBookingRepository { get;private set;}   
        public IHotelFacilitiesRepositories HotelFacilitiesRepositories { get;private set;}
        public IVisaRepository VisaRepository { get;private set;}   
        public ProjectUnitOfWork(ApplicationDbContext dbContext, ITourRepository tourRepository,
            ITourDetailsRepository tourDetailsRepository,
            IHotelRepository hotelRepository,
            IRoomRepository roomRepository,
            IHotelFacilitiesRepositories hotelFacilities,
            IConsultationFormRepository formRepository,
            IHotelBookingRepository hotelBookingRepository,
            IVisaRepository visaRepository) : base(dbContext)
        {
            TourRepository = tourRepository;
            TourDetailsRepository = tourDetailsRepository;
            ConsultationFormRepository = formRepository;
            HotelRepository = hotelRepository;
            RoomRepository = roomRepository;
            HotelFacilitiesRepositories = hotelFacilities;
            HotelBookingRepository = hotelBookingRepository;
            VisaRepository = visaRepository;
        }
    }
}
