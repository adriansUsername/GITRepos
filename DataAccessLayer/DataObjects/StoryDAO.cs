using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataObjects
{
    public class StoryDAO // STORY DATA ACCESS OBJECT
    {
        public int storyID { get; set; }
        public string storyFileName { get; set; } // will be used to store the name of the file and the .txt
        public int storyRating { get; set; }
        public string storyRestriction { get; set; }
        public int storyUserID { get; set; }
        public int storyGenreID { get; set; }
        public string storyTitle { get; set; }
    }
}
