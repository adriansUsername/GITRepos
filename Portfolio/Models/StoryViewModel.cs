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
        public List<RatingsModel> ratingList { get; set; }
        public List<RestrictionModel> restrictionList { get; set; }
        public List<GenreModel> genreList { get; set; }
        public List<SelectListItem> genreOptions { get; set; }
        public List<SelectListItem> restrictionOptions { get; set; }

        public StoryViewModel()
        {
            singleStory = new StoryModel();
            storyList = new List<StoryModel>();
            userList = new List<UserModel>();
            ratingList = new List<RatingsModel>();
            restrictionList = new List<RestrictionModel>();
            genreList = new List<GenreModel>();
            restrictionOptions = new List<SelectListItem>();
            genreOptions = new List<SelectListItem>();
        }
    }
}