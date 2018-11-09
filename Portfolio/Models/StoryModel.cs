using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Portfolio.Models
{
    public class StoryModel
    {
        [Required]
        [DisplayName("Story ID#")]
        public int storyID { get; set; } = 0;

        [Required]
        [DisplayName("File Location")]
        public string storyURL { get; set; }

        [DisplayName("Rating")]
        public double storyRating { get; set; }

        [Required]
        [DisplayName("Restriction ID#")]
        public int storyRestrictionID { get; set; }

        [Required]
        [DisplayName("User ID#")]
        public int storyUserID { get; set; }

        [Required]
        [DisplayName("Genre ID#")]
        public int storyGenreID { get; set; }

        [Required]
        [DisplayName("Title")]
        public string storyTitle { get; set; }

        [DisplayName("Editor ID#")]
        public int storyEditorID { get; set; }

        [Required]
        public bool storyPublic { get; set; }

        public bool isSelected { get; set; } = false;
    }
}