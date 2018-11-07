using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portfolio.Models
{
    public class StoryViewModel
    {
        StoryModel singleStory { get; set; }
        List<StoryModel> storyList { get; set; }

        public StoryViewModel()
        {
            singleStory = new StoryModel();
            storyList = new List<StoryModel>();
        }
    }
}