using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portfolio.Models
{
    public class UpdateViewModel
    {
        UpdateModel singleUpdate { get; set; }
        List<UpdateModel> updateList { get; set; }

        public UpdateViewModel()
        {
            singleUpdate = new UpdateModel();
            updateList = new List<UpdateModel>();
        }
    }
}