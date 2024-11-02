using Blogsite.Infrastructure.Entities;
using Blogsite.Infrastructure.Exceptions;
using Blogsite.Infrastructure.UOWork;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogsite.Infrastructure.Services
{
    public class TourDetailsServices: ITourDetailsServices
    {
        private IProjectUnitOfWork _projectUnitOfWork;
        public TourDetailsServices(IProjectUnitOfWork unitOfWork)
        {
                _projectUnitOfWork= unitOfWork; 
        }

        public void AddTourDetails(TourDetails tourDetails)
        {
            if (tourDetails is null)
            {
                throw new InvalidOperationException("Tour details  can not be null");
            }
            var tourCount = _projectUnitOfWork.TourDetailsRepository.GetCount(c => c.Location == tourDetails.Location);

            if (tourCount > 0)
            {
                throw new DuplicateException("Same tour details exist");
            }
            _projectUnitOfWork.TourDetailsRepository.Add(tourDetails);
            _projectUnitOfWork.Save();
        }
        public void EditDetails(TourDetails details)
        {
            if (details is null)
            {
                throw new InvalidOperationException("details can not be null");
            }

            var entity = _projectUnitOfWork.TourDetailsRepository.GetById(details.Id);

            if (entity == null)
                throw new InvalidOperationException("details can not be null");

            // entity.Id = tour.Id;
            entity.Overview = details.Overview;
            entity.Location = details.Location;
            entity.Timing = details.Timing;
            entity.InclusionExclusion = details.InclusionExclusion;
            entity.Description = details.Description;
            entity.AdditionalInformation = details.AdditionalInformation;
            entity.TravelTips = details.TravelTips;
            entity.Options = details.Options;
            entity.Policy = details.Policy;

            _projectUnitOfWork.TourDetailsRepository.Edit(entity);
            _projectUnitOfWork.Save();
        }
        public TourDetails GetByid(int id)
        {
            var entity = _projectUnitOfWork.TourDetailsRepository.GetById(id);
            return entity;
        }
        public void DeleteTourDetails(int id)
        {
            var entity = _projectUnitOfWork.TourDetailsRepository.GetById(id);
            if (entity == null)
            {
                throw new InvalidOperationException("Tour details is not found");
            }
            _projectUnitOfWork.TourDetailsRepository.Remove(entity);
            _projectUnitOfWork.Save();
        }
        public (IList<TourDetails> tours, int total, int totalDisplay) GetTourdetailsList(int pageindex, int pagesize, string searchText, string orderBy)
        {
            (IList<TourDetails> data, int total, int totalDisplay) result = (null, 0, 0);
            if (string.IsNullOrWhiteSpace(searchText))
            {
                result = _projectUnitOfWork.TourDetailsRepository.GetDynamic(null, null, null, pageindex, pagesize, true);
            }
            else
            {
                result = _projectUnitOfWork.TourDetailsRepository.GetDynamic(x => x.Location.ToLower() == searchText.ToLower()
                , null, null, pageindex, pagesize, true);
            }
            return (result.data, result.total, result.totalDisplay);
        }
       

    }
}


