using System;
using System.Collections.Generic;

namespace Entities
{
    public class HotelDetails:HotelSummary
    {
        public string Description { get; set; }
        public List<Facilitate> Facilitaties { get; set; }
    }
}
