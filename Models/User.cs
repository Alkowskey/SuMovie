using System;
using System.Collections.Generic;
using System.Linq;

namespace SuMovie.Models
{
    public class User{
        public User(String username, String passwordHash){
            Username = username;
            PasswordHash = passwordHash;
            CreationDate = DateTime.Now;

            WatchedMovies = new List<Movie>();
        }
        public User(){}
        public int Id {get;set;}
        public String Username {get;set;}
        public String PasswordHash {get;set;}

        public DateTime CreationDate {get;set;}
        public List<Movie> WatchedMovies {get;set;}

    }

}