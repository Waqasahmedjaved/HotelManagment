using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Interface
{
    public interface IHotelService
    {
        List<HotelSummary> SearchHotel(HotelSearchRequest request);

        HotelDetails HotelDetail(int hotelId);

        HotelBookingResponse HotelBooking(HotelBookingRequest request);
    }
}
