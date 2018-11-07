using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portfolio.Models
{
    public class UpdateModel
    {
        public int updateID { get; set; }
        public DateTime updateDate { get; set; }
        public int updateStoryID { get; set; }
        public string updateText { get; set; }
        public int updateUserID { get; set; }
        public bool updateApproved { get; set; }
        public bool isSelected { get; set; } = false;
    }
}