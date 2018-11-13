using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portfolio.Models
{
    public class StoryViewModel
    {
        public StoryModel singleStory { get; set; }
        public List<StoryModel> storyList { get; set; }
        public List<UserModel> userList { get; set; }
        public GenreViewModel genreViewModel { get; set; }
        public RestrictionViewModel restrictionViewModel { get; set; }
        public RatingsViewModel ratingsViewModel { get; set; }

        public StoryViewModel()
        {
            singleStory = new StoryModel();
            storyList = new List<StoryModel>();
            userList = new List<UserModel>();
            genreViewModel = new GenreViewModel();
            restrictionViewModel = new RestrictionViewModel();
            ratingsViewModel = new RatingsViewModel();
        }
    }
}