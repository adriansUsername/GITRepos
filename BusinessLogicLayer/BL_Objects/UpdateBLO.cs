using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.BL_Objects
{
    public class UpdateBLO // Update Business Logic Object
    {
        public int updateID { get; set; }
        public DateTime updateDate { get; set; }
        public int updateStoryID { get; set; }
        public string updateURL { get; set; }
        public int updateUserID { get; set; }
        public bool updateApproved { get; set; }
    }
}
