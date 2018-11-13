using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portfolio.Models
{
    public class RestrictionViewModel
    {
        public RestrictionModel singleRestriction { get; set; }
        public List<RestrictionModel> restrictionList { get; set; }
        public List<SelectListItem> restrictionOptions { get; set; }

        public RestrictionViewModel()
        {
            singleRestriction = new RestrictionModel();
            restrictionList = new List<RestrictionModel>();
            restrictionOptions = new List<SelectListItem>();
        }
    }
}