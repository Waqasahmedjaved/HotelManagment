using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class HotelBookingRequest
    {
        public int HotelId { get; set; }
        public string HotelName { get; set; }
        public DateTime CheckInDateTime { get; set; }
        public DateTime CheckOutDateTime { get; set; }

    }
}
