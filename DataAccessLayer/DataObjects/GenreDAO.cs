﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataObjects
{
    public class GenreDAO // Genre Data Acess Object
    {
        public int genreID { get; set; }
        public string genreName { get; set; }
        public string genreDescription { get; set; }
        public bool genreIsFiction { get; set; }
    }
}
