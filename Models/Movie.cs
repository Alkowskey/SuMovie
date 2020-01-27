using System;
using System.Collections.Generic;
using System.Linq;

namespace SuMovie.Models
{
    public class Movie{
        public Movie(String imgUrl, String title, List<Person> stars, String genres, DateTime releaseDate, String rate, int metaScore){
            ImgUrl = imgUrl;
            Title = title;
            Stars = stars;
            Genres = genres;
            ReleaseDate = releaseDate;
            Rate = rate;
            MetaScore = metaScore;
            
        }
        public Movie(){}
        public int Id {get;set;}
        public String ImgUrl{get;set;}
        public String Title {get;set;}
        public List<Person> Stars {get;set;}
        public String Genres{get;set;}

        public DateTime ReleaseDate {get;set;}

        public String Rate {get;set;}
        public int MetaScore{get;set;}


    }

}