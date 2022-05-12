using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarCore.Dtos
{
    public class Response<T>
    {
        public T Data { get; set; }
<<<<<<< HEAD
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }
        public HttpStatusCode ResponseCode { get; set; }
=======
        public string Message { get; set; }
        public HttpStatusCode ResponseCode { get; set; }
        public bool IsSuccessful { get; set; }
>>>>>>> 9f7bd7411c370e2fcee6076d7a19d140eebbbb92
    }
}
