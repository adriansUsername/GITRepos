using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portfolio.Models
{
    public class RatingsViewModel
    {
        public RatingsModel singleRatings { get; set; }
        public List<RatingsModel> ratingsList { get; set; }

        public RatingsViewModel()
        {
            singleRatings = new RatingsModel();
            ratingsList = new List<RatingsModel>();
        }
    }
}