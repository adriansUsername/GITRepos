using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portfolio.Models
{
    public class RatingsViewModel
    {
        RatingsModel singleRating { get; set; }
        List<RatingsModel> ratingList { get; set; }

        public RatingsViewModel()
        {
            singleRating = new RatingsModel();
            ratingList = new List<RatingsModel>();
        }
    }
}