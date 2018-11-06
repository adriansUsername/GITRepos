using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.BL_Objects
{
    public class StoryBLO // Story Business Logic Object
    {
        public int storyID { get; set; }
        public string storyFileName { get; set; } // will be used to store the name of the file and file extension
        public int storyRating { get; set; }
        public int storyRestrictionID { get; set; }
        public int storyUserID { get; set; }
        public int storyGenreID { get; set; }
        public string storyTitle { get; set; }
        public int storyEditorID { get; set; }
    }
}
