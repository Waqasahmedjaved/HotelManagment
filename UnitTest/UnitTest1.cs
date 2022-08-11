using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service;
using Service.Interface;
using System;
using System.Collections.Generic;
using Xunit.Sdk;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        HotelService hotelService = new HotelService();
        

        [TestMethod]
        public void TestHotelBooking()
        {
           var res = hotelService.HotelBooking(
                new Entities.HotelBookingRequest { CheckInDateTime = DateTime.Now.AddDays(2), CheckOutDateTime = DateTime.Now.AddDays(4), HotelId = 2, HotelName = "", });
            #region Expected Data
            var expectedResponse = new Response<HotelBookingResponse>();
            expectedResponse.Data = new HotelBookingResponse
            {
                BookingStatus = "BookingConfirm",
                BookingId = "Ab-123456789"
            };
            expectedResponse.Error = "";
            expectedResponse.StatusCode = System.Net.HttpStatusCode.OK;
            #endregion
            Assert.AreEqual(expectedResponse.ToString(), res.ToString());
        }

        [TestMethod]
        public void TestHotelDetail()
        {
            var res = hotelService.HotelDetail(1);

            #region Expected Data
            var facilitaties = new List<Facilitate>();
            facilitaties.Add(new Facilitate { Type = "Breakfast" });
            facilitaties.Add(new Facilitate { Type = "Wifi" });
            facilitaties.Add(new Facilitate { Type = "Parking" });
            facilitaties.Add(new Facilitate { Type = "Spa" });
            var expectedResponse = new Response<HotelDetails>();
            var response = new HotelDetails();
            response = new HotelDetails
            {
                HotelId = 1,
                HotelName = "Shaid Montana",
                Address = new Address { AddressLine1 = "Street No 2", AddressLine2 = "Main highway", City = "Dubai", PhoneNumber = "222222222" },
                OldPerNightRate = 100,
                PerNightRate = 70,
                Rating = 4.5,
                Facilitaties = facilitaties,
                Distance = 2.5,
                Description = "Featuring an outdoor swimming pool and views of city, Flora Inn Hotel is located in Dubai, just a 10 minute drive from Deira City Center Shopping Mall, "

            };
            expectedResponse.Data = response;
            expectedResponse.Error = "";
            expectedResponse.StatusCode = System.Net.HttpStatusCode.OK;

            #endregion

            Assert.AreEqual(expectedResponse.ToString(), res.ToString());
        }

        [TestMethod]
        public void TestSearchHotel()
        {
            var res = hotelService.SearchHotel(
                 new Entities.HotelSearchRequest {  HotelName = "City", });
            #region Expected Data
            var expectedResponse = new Response<List<HotelSummary>>();
            var hotelList = new List<HotelSummary>();
            var facilitaties = new List<Facilitate>();
            facilitaties.Add(new Facilitate { Type = "Breakfast" });
            facilitaties.Add(new Facilitate { Type = "Wifi" });
            facilitaties.Add(new Facilitate { Type = "Parking" });
            facilitaties.Add(new Facilitate { Type = "Spa" });
            hotelList.Add(new HotelSummary
            {
                HotelId = 2,
                HotelName = "City Hotel",
                Address = new Address { AddressLine1 = "Street No 2", AddressLine2 = "Main highway", City = "Dubai", PhoneNumber = "222222222" },
                OldPerNightRate = 80,
                PerNightRate = 50,
                Rating = 4,
                Facilitaties = facilitaties,
                Distance = 3.2,

            });
            expectedResponse.Data = hotelList;
            expectedResponse.Error = "";
            expectedResponse.StatusCode = System.Net.HttpStatusCode.OK;
            #endregion
            Assert.AreEqual(expectedResponse.ToString(), res.ToString());
        }
    }
}
