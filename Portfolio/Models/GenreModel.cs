using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Portfolio.Models
{
    public class GenreModel
    {
        [Required]
        [DisplayName("Genre ID#")]
        public int genreID { get; set; } = 0;

        [Required]
        [DisplayName("Genre")]
        [StringLength(35, ErrorMessage = "The genre name must not exceed 35 characters!")]
        public string genreName { get; set; }

        [Required]
        [DisplayName("Description")]
        [StringLength(70, ErrorMessage ="The genre description must not exceed 70 characters!")]
        public string genreDescription { get; set; }

        [Required]
        [DisplayName("Fictional")]
        public bool genreIsFiction { get; set; }

        public bool isSelected { get; set; } = false;
    }
}