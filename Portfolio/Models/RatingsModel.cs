using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portfolio.Models
{
    public class RatingsModel
    {
        public int ratingsID { get; set; }
        public int ratingsValue { get; set; }
        public int ratingsStoryID { get; set; }
        public int ratingsUserID { get; set; }
        public bool isSelected { get; set; } = false;
    }
}