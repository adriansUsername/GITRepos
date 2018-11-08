using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portfolio.Models
{
    public class StoryModel
    {
        public int storyID { get; set; }
        public string storyURL { get; set; }
        public int storyRating { get; set; }
        public int storyRestrictionID { get; set; }
        public int storyUserID { get; set; }
        public int storyGenreID { get; set; }
        public string storyTitle { get; set; }
        public int storyEditorID { get; set; }
        public bool storyPublic { get; set; }
        public bool isSelected { get; set; } = false;
    }
}