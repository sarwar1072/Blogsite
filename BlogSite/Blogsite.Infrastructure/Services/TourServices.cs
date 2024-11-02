using Blogsite.Infrastructure.Entities;
using Blogsite.Infrastructure.Exceptions;
using Blogsite.Infrastructure.UOWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogsite.Infrastructure.Services
{
    public class TourServices:ITourServices
    {
        private readonly IProjectUnitOfWork _projectUnitOfWork;
        public TourServices(IProjectUnitOfWork projectUnitOfWork)
        {
                _projectUnitOfWork = projectUnitOfWork;
        }
        public void  AddTour(Tour tour)
        {
            if (tour is null)
            {
                throw new InvalidOperationException("Tour can not be null");
            }
            var tourCount =  _projectUnitOfWork.TourRepository.GetCount(c => c.TourName == tour.TourName);

            if(tourCount > 0) {
                throw new DuplicateException("Same tour exist");
            }
             _projectUnitOfWork.TourRepository.Add(tour); 
             _projectUnitOfWork.Save();
        }
        public void AddConsulationForm(ConsultationForm Form)
        {

            if (Form is null)
            {
                throw new InvalidOperationException("Tour details  can not be null");
            }

            _projectUnitOfWork.ConsultationFormRepository.Add(Form);
            _projectUnitOfWork.Save();
        }
        public (IList<ConsultationForm> forms, int total, int totalDisplay) GetConsultForm(int pageindex, int pagesize, string searchText, string orderBy)
        {

            var result = _projectUnitOfWork.ConsultationFormRepository.GetDynamic(null, null, null, pageindex, pagesize, true);

            return (result.data, result.total, result.totalDisplay);
        }
        public  (IList<Tour> tours,int total,int totalDisplay)GetTourList(int pageindex, int pagesize,string searchText, string orderBy)
        {
            (IList<Tour> data, int total, int totalDisplay) result = (null, 0, 0);
            if (string.IsNullOrWhiteSpace(searchText))
            {
                result = _projectUnitOfWork.TourRepository.GetDynamic(null, null, null, pageindex, pagesize, true);
            }
            else
            {
                result = _projectUnitOfWork.TourRepository.GetDynamic(x => x.TourName.ToLower() == searchText.ToLower()
                || x.Destination.ToLower() == searchText.ToLower(), null, null, pageindex, pagesize, true);
            }
            return (result.data, result.total, result.totalDisplay);
        }
        public Tour GetTourDetails(int id)
        {
            var entity=_projectUnitOfWork.TourRepository.GetFirstOrDefault(x=>x.Id==id,"Images,TourDetails");
            return entity;
        }
        public  void EditTour(Tour tour) 
        {
            if (tour is null)
            {
                throw new InvalidOperationException("Question can not be null");
            }

            var entity= _projectUnitOfWork.TourRepository.GetById(tour.Id);   
            
            if(entity ==null)
                throw new InvalidOperationException("Question can not be null");
            

           // entity.Id = tour.Id;
                entity.TourName = tour.TourName;    
                entity.TourUrl = tour.TourUrl;  
                entity.Destination = tour.Destination;
                entity.MaxiMumPeople = tour.MaxiMumPeople;
                entity.MiniMumPeople = tour.MiniMumPeople;  
                entity.Requirements = tour.Requirements;    
                entity.CancellationTerm = tour.CancellationTerm;    
                entity.Price = tour.Price;
                entity.SpotsAvailable = tour.SpotsAvailable;    
            
                 _projectUnitOfWork.TourRepository.Edit(entity);  
                 _projectUnitOfWork.Save();   
        }
        public Tour GetByid(int id)
        {
            var entity=_projectUnitOfWork.TourRepository.GetById(id);
            return entity;  
        }
        public  void DeleteTour(int id)
        {
            var entity=  _projectUnitOfWork.TourRepository.GetById(id);    
            if(entity == null) {
                throw new InvalidOperationException("Tour is not found");
            }
             _projectUnitOfWork.TourRepository.Remove(entity);
             _projectUnitOfWork.Save();   
        }
        public IList<Tour> ListOfTour(string destination)
        {
            var list=_projectUnitOfWork.TourRepository.Get(x=>x.Destination.ToLower()==destination.ToLower(),null,
                null,false);  

            return list;    
        }
        public IList<Tour> ListOfTourName()
        {
            var list = _projectUnitOfWork.TourRepository.GetAll();
           
            return list;
        }
        public Tour TourDetailsById(int id)
        {
            var tour = _projectUnitOfWork.TourRepository.GetFirstOrDefault(c=>c.Id==id,"Images");

            //if (tour != null)
            //{
            //    tour.Images = tour.Images.Where(img => img.TourId == id).ToList();  // Filter images manually
            //}
            return tour;
        }
        public IList<TourDetails> GetTypeOfTour()
        {
            return _projectUnitOfWork.TourDetailsRepository.GetAll();
        }

    }
}
