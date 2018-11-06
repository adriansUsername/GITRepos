using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataObjects
{
    public class RatingsDAO // Ratings Data Access Object
    {
        public int ratingsID { get; set; }
        public int ratingsValue { get; set; }
        public int ratingsStoryID { get; set; }
        public int ratingsUserID { get; set; }
    }
}
