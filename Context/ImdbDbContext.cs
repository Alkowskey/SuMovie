using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SuMovie.Models;

using System.Linq;
using System.Data;

namespace SuMovie.Context
{
    public class ImdbDbContext : DbContext
    {
        public ImdbDbContext(DbContextOptions<ImdbDbContext> options) : base (options){
            
        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Person> Persons { get; set; }

        public List<Movie> addManyMovies(List<Movie> movies){


            var newMovieTitles = movies.Select(m => m.Title).Distinct().ToArray();
            var moviesInDb = Movies.Where(m => newMovieTitles.Contains(m.Title))
                                        .Select(m => m.Title).ToArray();
            var moviesNotInDb = movies.Where(m => !moviesInDb.Contains(m.Title));
            foreach(Movie m in moviesNotInDb){
                Movies.Add(m);
            }


            this.SaveChanges();

            return movies;
        }
    }
}