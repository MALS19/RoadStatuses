using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2.Entity
{
  public  class ErrorAPI
    {
        public string ExceptionType { get; set; }

        public int HttpStatusCode { get; set; }

        public string HttpStatus { get; set; }
       
      public string Message { get; set; }


    }
}
