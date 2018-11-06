using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portfolio.Models
{
    public class ErrorModel // Error Model Object
    {
        public int errorID { get; set; }
        public DateTime errorDate { get; set; }
        public string errorType { get; set; }
    }
}