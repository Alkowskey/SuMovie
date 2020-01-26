using System;
using System.Collections.Generic;
using System.Linq;


namespace SuMovie.Models
{
    public class WatchedMovie{
        public WatchedMovie(Movie movie, int score){
            Movie = movie;
            Score = score;
            Date = DateTime.Now;
            
        }
        public WatchedMovie(){}
        public int Id {get;set;}
        public Movie Movie {get;set;}
        public User User{get;set;}
        public int Score{get;set;} //0 - 100

        public DateTime Date{get;set;}


    }

}