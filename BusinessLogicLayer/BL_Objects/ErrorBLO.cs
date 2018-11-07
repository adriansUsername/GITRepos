using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.BL_Objects
{
    public class ErrorBLO // Error Business Logic Object
    {
        public int errorID { get; set; }
        public DateTime errorDate { get; set; }
        public string errorMessage { get; set; }
        public string errorTrace { get; set; }
        public string errorSite { get; set; }
    }
}
