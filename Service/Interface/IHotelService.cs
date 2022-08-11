using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Interface
{
    public interface IHotelService
    {
        Response<List<HotelSummary>> SearchHotel(HotelSearchRequest request);

        Response<HotelDetails> HotelDetail(int hotelId);

        Response<HotelBookingResponse> HotelBooking(HotelBookingRequest request);
    }
}
