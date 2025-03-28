﻿using Blogsite.Infrastructure.Entities;
using Blogsite.Infrastructure.UOWork;
using Blogsite.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.EntityFrameworkCore;

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

            var name = _unitOfWork.HotelRepository.GetCount(x => x.Name == hotel.Name);

            if (name != 0)
                throw new DuplicateException("hotel name can be same");

            _unitOfWork.HotelRepository.Add(hotel);
            _unitOfWork.Save();
        }
        public IList<Hotel> GetAlHotesls()
        {
            return _unitOfWork.HotelRepository.GetAll().Take(4).ToList();
        }
        public IList<Hotel> GetAlHoteslsForDropDown()
        {
            return _unitOfWork.HotelRepository.GetAll().DistinctBy(c => c.Location).ToList();
        }
        public IList<string> GetAllHoteslsWithoutLimit()
        {
            var entity = _unitOfWork.HotelRepository.GetAll();

            // Select distinct locations from the entity list
            var locations = entity
                .Select(c => c.Location)
                .Where(location => !string.IsNullOrEmpty(location)) // Optional: Filter out null or empty locations
                .Distinct()
                .ToList();

            return locations;
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
            entity.AvailableRooms = hotel.AvailableRooms;

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
        //public IList<Hotel> SearchedHotelList(string Location, DateTime CheckInDate, DateTime CheckOutDate, int NumberOfGuests)
        //{
        //    var result = _unitOfWork.HotelRepository.GetDynamic(s => s.Location.ToLower().Contains(Location.ToLower()), null,
        //                       c => c.Include(h => h.Rooms).ThenInclude(r => r.HotelBookings), false)
        //                       .Where(h => h.Rooms.Any(r => r.Capacity >= NumberOfGuests && r.HotelBookings.All(b =>
        //                       (CheckInDate < b.CheckInDate && CheckOutDate <= b.CheckInDate) || (CheckInDate >= b.CheckOutDate)))).ToList();

        //    return result;
        //}
        //public IList<Hotel> SearchedHotelList(string Location, DateTime CheckInDate, DateTime CheckOutDate, int NumberOfGuests)
        //{
        //    var result = _unitOfWork.HotelRepository.GetDynamic(s => s.Location.ToLower().Contains(Location.ToLower()),

        //              null, c => c.Include(h => h.Rooms).ThenInclude(r => r.HotelBookings), false)

        //               .Where(h => h.Rooms.Any(r => r.Capacity >= NumberOfGuests &&

        //            !r.HotelBookings.Any(b => (CheckInDate >= b.CheckInDate && CheckOutDate <= b.CheckOutDate)))).ToList();

        //    return result;
        //}
        public IList<Hotel> SearchedHotelList(string location, DateTime checkInDate, DateTime checkOutDate, int numberOfGuests)
        {
            var result = _unitOfWork.HotelRepository.GetDynamic(
                h => h.Location.ToLower().Contains(location.ToLower()),
                null,
                h => h.Include(h => h.Rooms).ThenInclude(r => r.HotelBookings),
                false
            )
            .Where(h => h.Rooms.Any(r =>
                r.Capacity >= numberOfGuests && // Room capacity must be sufficient
                !r.HotelBookings.Any(b =>       // Room must not be booked in the specified date range
                    checkInDate < b.CheckOutDate && checkOutDate > b.CheckInDate)))
            .ToList();

            return result;
        }

        //public Hotel SearchedRoomListWithHotel(int id,string Location, DateTime CheckInDate, DateTime CheckOutDate, int NumberOfGuests)
        //{
        //    var result = _unitOfWork.HotelRepository.GetDynamic(h => h.Id == id && h.Location.ToLower().Contains(Location.ToLower()),null,

        //                  c => c.Include(d => d.Images).Include(i => i.HotelFacilities).Include(h => h.Rooms).ThenInclude(r => r.HotelBookings), false)

        //                .Where(h => h.Rooms.Any(r => r.Capacity >= NumberOfGuests && !r.HotelBookings.Any(b =>

        //                CheckInDate <= b.CheckOutDate && CheckOutDate >= b.CheckInDate))).FirstOrDefault();

        //    return result;
        //}
        public Hotel SearchedRoomListWithHotel(int id, string location, DateTime checkInDate, DateTime checkOutDate, int numberOfGuests)
        {
            var hotel = _unitOfWork.HotelRepository.GetDynamic(
                h => h.Id == id && h.Location.ToLower().Contains(location.ToLower()),
                null,
                h => h.Include(d => d.Images)
                      .Include(i => i.HotelFacilities)
                      .Include(h => h.Rooms).ThenInclude(r => r.HotelBookings),
                false
            ).FirstOrDefault();

            // If the hotel exists, filter out rooms that are not booked for the specified date range
            if (hotel != null)
            {
                hotel.Rooms = hotel.Rooms
                    .Where(r => r.Capacity >= numberOfGuests &&
                                !r.HotelBookings.Any(b =>
                                    checkInDate < b.CheckOutDate && checkOutDate > b.CheckInDate))
                    .ToList();
            }

            return hotel;
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
        public Room GetRoomDetailsById(int id) 
        {
            var roomData = _unitOfWork.RoomRepository.GetDynamic(c => c.Id == id, x => x.Include(y => y.Hotel));
            return roomData;
        }

    }
}
