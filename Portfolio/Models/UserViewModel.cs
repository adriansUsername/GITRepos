﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portfolio.Models
{
    public class UserViewModel
    {
        public UserModel singleUser { get; set; }
        public List<UserModel> userList { get; set; }

        public UserViewModel()
        {
            singleUser = new UserModel();
            userList = new List<UserModel>();
        }
    }
}