﻿using Blogsite.Infrastructure.Entities;
using Blogsite.Infrastructure.Exceptions;
using Blogsite.Infrastructure.UOWork;
using System;
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
        public async Task AddTour(Tour tour)
        {
            if (tour is null)
            {
                throw new InvalidOperationException("Tour can not be null");
            }
            var tourCount = await _projectUnitOfWork.TourRepository.GetCountAsync(c => c.TourName == tour.TourName);

            if(tourCount > 0) {
                throw new DuplicateException("Same tour exist");
            }
            await _projectUnitOfWork.TourRepository.AddAsync(tour); 
            await _projectUnitOfWork.SaveAsync();
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

    }
}
