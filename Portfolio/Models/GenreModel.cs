using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portfolio.Models
{
    public class GenreModel
    {
        public int genreID { get; set; }
        public string genreName { get; set; }
        public string genreDescription { get; set; }
        public bool genreIsFiction { get; set; }
        public bool isSelected { get; set; } = false;
    }
}