using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.BL_Objects
{
    public class GenreBLO // Genre Business Logic Object
    {
        public int genreID { get; set; }
        public string genreName { get; set; }
        public string genreDescription { get; set; }
        public bool genreIsFiction { get; set; }
    }
}
