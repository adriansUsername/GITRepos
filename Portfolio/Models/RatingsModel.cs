using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Portfolio.Models
{
    public class RatingsModel
    {
        [DisplayName("Rating ID#")]
        public int ratingsID { get; set; }

        [DisplayName("Rating")]
        public int ratingsValue { get; set; }

        [DisplayName("Story ID#")]
        public int ratingsStoryID { get; set; }

        [DisplayName("User ID#")]
        public int ratingsUserID { get; set; }

        public bool isSelected { get; set; } = false;
    }
}