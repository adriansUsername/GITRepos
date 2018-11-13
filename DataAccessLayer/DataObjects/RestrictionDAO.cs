using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataObjects
{
    public class RestrictionDAO // Restriction Data Access Object
    {
        public int restrictionID { get; set; }
        public string restrictionName { get; set; }
        public int restrictionAge { get; set; }
    }
}
