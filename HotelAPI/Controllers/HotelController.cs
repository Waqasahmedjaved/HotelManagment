using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private IHotelService hotelService;
         
        public HotelController(IHotelService hotelServiceObj )
        {
            this.hotelService = hotelServiceObj;
        }

        [HttpGet("details")]
        public ActionResult Details(int hotelId)
        {
            var result = this.hotelService.HotelDetail(hotelId);
            return GetOKResult(result);
        }


        [HttpPost("search")]
        public ActionResult Search(HotelSearchRequest request)
        {
            var result = this.hotelService.SearchHotel(request);

            return GetOKResult(result);
        }

        [HttpPost("booking")]
        public ActionResult HotelBooking(HotelBookingRequest request)
        {
            var result = this.hotelService.HotelBooking(request);

            return GetOKResult(result);
        }



        protected ActionResult GetOKResult(object content = null)
        {
            return GetStatusResult(System.Net.HttpStatusCode.OK, content);
        }

        protected ActionResult GetStatusResult(System.Net.HttpStatusCode httpStatus, object content)
        {
            if (content == null)
            {
                return StatusCode((int)(httpStatus));
            }

            return StatusCode((int)(httpStatus), content);
        }
    }
}
