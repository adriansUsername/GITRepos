using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portfolio.Models
{
    public class UpdateViewModel
    {
        public UpdateModel singleUpdate { get; set; }
        public List<UpdateModel> updateList { get; set; }
        public List<UserModel> userList { get; set; }

        public UpdateViewModel()
        {
            singleUpdate = new UpdateModel();
            updateList = new List<UpdateModel>();
            userList = new List<UserModel>();
        }
    }
}