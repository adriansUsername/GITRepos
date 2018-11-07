using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portfolio.Models
{
    public class GenreViewModel
    {
        GenreModel singleGenre { get; set; }
        List<GenreModel> genreList { get; set; }

        public GenreViewModel()
        {
            singleGenre = new GenreModel();
            genreList = new List<GenreModel>();
        }
    }
}