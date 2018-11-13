using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portfolio.Models
{
    public class RoleViewModel
    {
        public RoleModel singleRole { get; set; }
        public List<RoleModel> roleList { get; set; }
        public List<SelectListItem> roleOptions { get; set; }

        public RoleViewModel()
        {
            singleRole = new RoleModel();
            roleList = new List<RoleModel>();
            roleOptions = new List<SelectListItem>();
        }
    }
}