using Entities;
using Service.Interface;
using System;
using System.Collections.Generic;

namespace Service
{
    public class HotelService: IHotelService
    {
        public HotelBookingResponse HotelBooking(HotelBookingRequest request)
        {
            return new HotelBookingResponse();
        }

        public HotelDetails HotelDetail(int hotelId)
        {
            return new HotelDetails();
        }

        public List<HotelSummary> SearchHotel(HotelSearchRequest request)
        {
            var obj = new List<HotelSummary>();
            obj.Add(new HotelSummary
            {

            });

            return obj;
        }
    }
}
