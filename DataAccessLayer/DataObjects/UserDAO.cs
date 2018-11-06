using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataObjects
{
    public class UserDAO // User Data Access Object
    {
        public int userID { get; set; }
        public string userName { get; set; }
        public string userPassword { get; set; }
        public string userFirstName { get; set; }
        public string userLastName { get; set; }
        public string userCity { get; set; }
        public string userState { get; set; }
        public string userCountry { get; set; }
        public int userRoleID { get; set; }
        public int userEdited { get; set; } // count of stories this user edited
    }
}