using Entities;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class HotelService: IHotelService
    {
        private List<Facilitate> facilitaties = null;

        public HotelService()
        {
            facilitaties = new List<Facilitate>();
            facilitaties.Add(new Facilitate { Type = "Breakfast" });
            facilitaties.Add(new Facilitate { Type = "Wifi" });
            facilitaties.Add(new Facilitate { Type = "Parking" });
            facilitaties.Add(new Facilitate { Type = "Spa" });
        }
        public Response<HotelBookingResponse> HotelBooking(HotelBookingRequest request)
        {
             var responseObj = new Response<HotelBookingResponse>();
            if(request.HotelId == 1)
            {
                responseObj.Data = new HotelBookingResponse
                {
                    BookingStatus = "Failed",
                    BookingId = null

                };
                responseObj.Error = "No room avaliable";
                responseObj.StatusCode = System.Net.HttpStatusCode.NoContent;
            }
            else
            {
                responseObj.Data = new HotelBookingResponse
                {
                    BookingStatus = "BookingConfirm",
                    BookingId = "Ab-123456789"

                };
                responseObj.Error = "";
                responseObj.StatusCode = System.Net.HttpStatusCode.OK;
            }
            return responseObj;
        }

        public Response<HotelDetails> HotelDetail(int hotelId)
        {
            var responseObj = new Response<HotelDetails>();
            var response = new HotelDetails();
            switch (hotelId)
            {
                case 1:
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
                    break;
                case 2:
                    response = new HotelDetails
                    {
                        HotelId = 2,
                        HotelName = "City Hotel",
                        Address =  new Address {AddressLine1 = "Street No 2",AddressLine2 = "Main highway" ,City="Dubai" ,PhoneNumber ="111111111"},
                        OldPerNightRate = 80,
                        PerNightRate = 50,
                        Rating = 4,
                        Facilitaties = facilitaties,
                        Distance = 3.2,
                        Description = "Located by Dubai Creek, Hyatt Regency Dubai Creek Heights offers modern accommodations with sleek interiors. The hotel features an outdoor swimming pool, 24-hour gym, a luxurious spa and kid play area"

                    };
                    break;
                case 3:
                    response = new HotelDetails
                    {
                        HotelId = 3,
                        HotelName = "Holiday Inn",
                        Address = new Address { AddressLine1 = "Air poart road", City = "Dubai", PhoneNumber = "333333333" },
                        OldPerNightRate = 80,
                        PerNightRate = 50,
                        Rating = 4,
                        Facilitaties = facilitaties,
                        Description = "Holiday Inn Express Dubai Airport is located opposite to Dubai International Airport Terminal 3, and is a short walk from Emirates Metro Station. "

                    };
                    break;
                default:
                    response = null;
                    break;
            }
            if (response != null)
            {
                responseObj.StatusCode = System.Net.HttpStatusCode.OK;
                responseObj.Error = "";
                responseObj.Data = response;
            }
            else
            {
                responseObj.StatusCode = System.Net.HttpStatusCode.NoContent;
                responseObj.Error = "No record found.";
                responseObj.Data = null;
            }

            
            return responseObj;
        }

        public Response<List<HotelSummary>> SearchHotel(HotelSearchRequest request)
        {
            var responseObj = new Response<List<HotelSummary>>();
            var hotelList = new List<HotelSummary>();


            hotelList.Add(new HotelSummary
            {
                HotelId = 1,
                HotelName = "Shaid Montana",
                Address = new Address { AddressLine1 = "Street No 2", AddressLine2 = "Main highway", City = "Dubai", PhoneNumber = "111111111" },
                OldPerNightRate = 100,
                PerNightRate = 70,
                Rating =4.5,
                Facilitaties = facilitaties,
                Distance = 2.5,
                
            });

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
            hotelList.Add(new HotelSummary
            {
                HotelId = 3,
                HotelName = "Holiday Inn",
                Address = new Address { AddressLine1 = "Air poart road", City = "Dubai", PhoneNumber = "333333333" },
                OldPerNightRate = 80,
                PerNightRate = 50,
                Rating = 4,
                Facilitaties = facilitaties,
                Distance = 4,

            });

            if(hotelList != null && request != null &&  !string.IsNullOrWhiteSpace(request.HotelName))
            {

                hotelList = hotelList.Where(x => x.HotelName.Contains(request.HotelName)).ToList();
            }

            if (hotelList != null &&  request != null && !string.IsNullOrWhiteSpace(request.Location))
            {

                hotelList = hotelList.Where(x => x.Address.AddressLine1.Contains(request.Location)).ToList();
            }

            if (hotelList != null)
            {
                responseObj.StatusCode = System.Net.HttpStatusCode.OK;
                responseObj.Error = "";
                responseObj.Data = hotelList;
            }
            else
            {
                responseObj.StatusCode = System.Net.HttpStatusCode.NoContent;
                responseObj.Error = "No record found.";
                responseObj.Data = null;
            }

            return responseObj;
        }
    }
}
