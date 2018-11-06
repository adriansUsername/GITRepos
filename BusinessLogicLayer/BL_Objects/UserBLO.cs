using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.BL_Objects
{
    public class UserBLO // Update Business Logic Object
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
        public int userWords { get; set; } // words per session
    }
}
