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

        // RETURN A POPULATED SELECT LIST ITEM LIST USING A RESTRICTION LIST
        public List<SelectListItem> populateOptions(List<RestrictionModel> restrictions)
        {
            List<SelectListItem> options = new List<SelectListItem>();

            foreach(RestrictionModel r in restrictions)
            {
                options.Add(new SelectListItem
                {
                    Text = r.restrictionName,
                    Value = r.restrictionID.ToString()
                });
            }

            return options;
        }

        // RETURN A POPULATED SELECT LIST ITEM LIST USING A GENRE LIST
        public List<SelectListItem> populateOptions(List<GenreModel> genres)
        {
            List<SelectListItem> options = new List<SelectListItem>();

            foreach (GenreModel g in genres)
            {
                options.Add(new SelectListItem
                {
                    Text = g.genreName,
                    Value = g.genreID.ToString()
                });
            }

            return options;
        }

        // GET RESTRICTION FROM LIST BY ID
        public RestrictionModel getByID(List<RestrictionModel> restrictions, int ID)
        {
            RestrictionModel restriction = new RestrictionModel();

            foreach (RestrictionModel r in restrictions)
            {
                if (r.restrictionID == ID)
                {
                    restriction = r;
                    break;
                }
            }

            return restriction;
        }

        // GET GENRE FROM LIST BY ID
        public GenreModel getByID(List<GenreModel> genres, int ID)
        {
            GenreModel genre = new GenreModel();

            foreach (GenreModel g in genres)
            {
                if (g.genreID == ID)
                {
                    genre = g;
                    break;
                }
            }

            return genre;
        }
    }
}