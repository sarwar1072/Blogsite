﻿using Blogsite.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogsite.Infrastructure.Services
{
    public interface IHotelBookingServices
    {
        List<HotelBooking> ListOfVBookedHotel(Guid UserId);

    }
}
