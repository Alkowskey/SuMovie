using System;
using System.Collections.Generic;
using SuMovie.Models;

namespace SuMovie.Models
{
    public class PersonMovie
    {
        public int PersonId { get; set; }
        public int MovieId { get; set; }

        public Movie Movie { get; set; }
        public Person Person { get; set; }




    }
}