using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataObjects
{
    public class RoleDAO // Role Data Access Object
    {
        public int roleID { get; set; }
        public string roleName { get; set; }
        public string roleDescription { get; set; }
    }
}
