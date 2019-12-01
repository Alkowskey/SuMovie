using System;
using System.Collections.Generic;
using System.Linq;

namespace SuMovie.Models
{
    public class Movie{
        public Movie(String title, Person director, List<Person> stars, DateTime releaseDate, String rate, int metaScore, String language){
            Title = title;
            Director = director;
            Stars = stars;
            ReleaseDate = releaseDate;
            Rate = rate;
            MetaScore = metaScore;
            Language = language;
            
        }
        public Movie(){}
        public int Id {get;set;}
        public String Title {get;set;}
        public Person Director {get;set;}

        public List<Person> Stars {get;set;}

        public DateTime ReleaseDate {get;set;}

        public String Rate {get;set;}
        public int MetaScore{get;set;}
        public String Language {get;set;}


    }

}