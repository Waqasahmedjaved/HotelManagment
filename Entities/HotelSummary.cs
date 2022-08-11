using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class HotelSummary
    {
        public int HotelId { get; set; }
        public string HotelName { get; set; }
        public Address Address { get; set; }
        public List<Facilitate> Facilitaties { get; set; }
        public decimal PerNightRate { get; set; }
        public decimal OldPerNightRate { get; set; }
        public double Rating { get; set; }
        public double Distance { get; set; }
    }
}
