using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portfolio.Models
{
    public class RestrictionViewModel
    {
        RestrictionModel singleRestriction { get; set; }
        List<RestrictionModel> restrictionList { get; set; }

        public RestrictionViewModel()
        {
            singleRestriction = new RestrictionModel();
            restrictionList = new List<RestrictionModel>();
        }
    }
}