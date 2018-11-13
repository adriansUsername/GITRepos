using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portfolio.Models
{
    public class GenreViewModel
    {
        public GenreModel singleGenre { get; set; }
        public List<GenreModel> genreList { get; set; }
        public List<SelectListItem> genreOptions { get; set; }

        public GenreViewModel()
        {
            singleGenre = new GenreModel();
            genreList = new List<GenreModel>();
            genreOptions = new List<SelectListItem>();
        }
    }
}