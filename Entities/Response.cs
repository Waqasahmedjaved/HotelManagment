using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Entities
{
    public class Response<T>
    {
        public T Data { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string Error { get; set; }
    }
}
