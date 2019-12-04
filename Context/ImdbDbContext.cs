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
        public DbSet<Person> People { get; set; }

        public List<Movie> addManyMovies(List<Movie> movies){


            var newMovieTitles = movies.Select(m => m.Title).Distinct().ToArray();
            var moviesInDb = Movies.Where(m => newMovieTitles.Contains(m.Title))
                                        .Select(m => m.Title).ToArray();
            var moviesNotInDb = movies.Where(m => !moviesInDb.Contains(m.Title));
            foreach(Movie m in moviesNotInDb){
                Movies.Add(m);
            }


            this.SaveChanges();

            return moviesNotInDb.ToList();
        }

        public List<Person> addManyPeople(List<Person> people){
            var newPeople = people.Select(p => p.Name).Distinct().ToArray();
            var peopleInDb = People.Where(p => newPeople.Contains(p.Name))
                                        .Select(p => p.Name).ToArray();
            var peopleNotInDb = people.Where(p => !peopleInDb.Contains(p.Name));
            foreach(Person p in peopleNotInDb){
                People.Add(p);
            }


            this.SaveChanges();

            
            return peopleNotInDb.ToList();

        }
    }
}