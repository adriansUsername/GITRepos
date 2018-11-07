using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portfolio.Models
{
    public class ErrorModel
    {
        public int errorID { get; set; }
        public DateTime errorDate { get; set; }
        public string errorMessage { get; set; }
        public string errorTrace { get; set; }
        public string errorSite { get; set; }
    }
}