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
    public class VisaServices: IVisaServices
    {
        private IProjectUnitOfWork _projectUnitOfWork;
        public VisaServices(IProjectUnitOfWork projectUnitOfWork)
        {
            _projectUnitOfWork = projectUnitOfWork;               
        }

        public void AddVisa(Visa visa)
        {
            if (visa is null)
            {
                throw new InvalidOperationException("Visa can not be null");
            }
            var tourCount = _projectUnitOfWork.VisaRepository.GetCount(c => c.Destination == visa.Destination);

            if (tourCount > 0)
            {
                throw new DuplicateException("Same visa exist");
            }
            _projectUnitOfWork.VisaRepository.Add(visa);
            _projectUnitOfWork.Save();
        }
        public (IList<Visa> visa, int total, int totalDisplay) GetVisaList(int pageindex, int pagesize, string searchText, string orderBy)
        {
            (IList<Visa> data, int total, int totalDisplay) result = (null, 0, 0);
            if (string.IsNullOrWhiteSpace(searchText))
            {
                result = _projectUnitOfWork.VisaRepository.GetDynamic(null, null, null, pageindex, pagesize, true);
            }
            else
            {
                result = _projectUnitOfWork.VisaRepository.GetDynamic(x => x.Destination.ToLower() == searchText.ToLower(),
                      null, null, pageindex, pagesize, true);
            }
            return (result.data, result.total, result.totalDisplay);
        }
        public void EditVisa(Visa visa)
        {
            if (visa is null)
            {
                throw new InvalidOperationException("visa can not be null");
            }

            var entity = _projectUnitOfWork.VisaRepository.GetById(visa.Id);

            if (entity == null)
                throw new InvalidOperationException("Visa can not be null");

            // entity.Id = tour.Id;
            entity.Destination = visa.Destination;
            entity.CoverUrl = visa.CoverUrl;
            entity.CardUrl = visa.CardUrl;
            entity.VisaType = visa.VisaType;
            entity.VisaMode = visa.VisaMode;
            entity.EntryType = visa.EntryType;  
            entity.VisaValidity = visa.VisaValidity;    
            entity.ProcessingTime = visa.ProcessingTime;    
            entity.MaxiMumStay = visa.MaxiMumStay; 
            entity.Price = visa.Price;
            entity.Requirements = visa.Requirements;
            entity.Policy = visa.Policy;

            _projectUnitOfWork.VisaRepository.Edit(entity);
            _projectUnitOfWork.Save();
        }
        public Visa GetByid(int id)
        {
            var entity = _projectUnitOfWork.VisaRepository.GetById(id);
            return entity;
        }
        public void DeleteVisa(int id)
        {
            var entity = _projectUnitOfWork.VisaRepository.GetById(id);
            if (entity == null)
            {
                throw new InvalidOperationException("Visa is not found");
            }
            _projectUnitOfWork.VisaRepository.Remove(entity);
            _projectUnitOfWork.Save();
        }
        public IList<Visa> ListOfVisa(string destination)
        {
            var list = _projectUnitOfWork.VisaRepository.Get(x => x.Destination.ToLower() == destination.ToLower(), null,
                null, false);

            return list;
        }
       
        ////public void AddConsulationForm(ConsultationForm Form)
        ////{

        ////    if (Form is null)
        ////    {
        ////        throw new InvalidOperationException("Tour details  can not be null");
        ////    }

        ////    _projectUnitOfWork.ConsultationFormRepository.Add(Form);
        ////    _projectUnitOfWork.Save();
        ////}
        //public (IList<ConsultationForm> forms, int total, int totalDisplay) GetConsultForm(int pageindex, int pagesize, string searchText, string orderBy)
        //{

        //    var result = _projectUnitOfWork.ConsultationFormRepository.GetDynamic(null, null, null, pageindex, pagesize, true);

        //    return (result.data, result.total, result.totalDisplay);
        //}

        //public Tour GetTourDetails(int id)
        //{
        //    var entity = _projectUnitOfWork.TourRepository.GetFirstOrDefault(x => x.Id == id, "Images,TourDetails");
        //    return entity;
        //}


        //public IList<Tour> ListOfPopularDestination()
        //{
        //    var list = _projectUnitOfWork.TourRepository.Get(null, null, null, false).DistinctBy(x => x.Destination).Take(6).ToList();
        //    //.DistinctBy(x => x.Destination)
        //    return list;
        //}
        //public IList<Tour> ListOfPopularTours()
        //{
        //    var list = _projectUnitOfWork.TourRepository.Get(null, null, null, false).OrderBy(x => x.Price).Take(4).ToList();
        //    //.DistinctBy(x => x.Destination)
        //    return list;
        //}
        //public IList<Tour> ListOfTourName()
        //{
        //    var list = _projectUnitOfWork.TourRepository.GetAll().DistinctBy(x => x.Destination).ToList();

        //    return list;
        //}
        //public Tour TourDetailsById(int id)
        //{
        //    var tour = _projectUnitOfWork.TourRepository.GetFirstOrDefault(c => c.Id == id, "Images");

        //    //if (tour != null)
        //    //{
        //    //    tour.Images = tour.Images.Where(img => img.TourId == id).ToList();  // Filter images manually
        //    //}
        //    return tour;
        //}



    }
}
