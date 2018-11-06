using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataObjects
{
    public class UpdateDAO // UPDATE DATA ACCESS OBJECT
    {
        public int updateID { get; set; }
        public DateTime updateDate { get; set; }
        public int updateStoryID { get; set; }
        public string updateFileName { get; set; } // will be used to store the name of the file and file extension
    }
}
