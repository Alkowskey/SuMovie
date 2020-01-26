using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SuMovie.Models;

using System.Linq;
using System.Data;
using System;
using System.IO;

using ChoETL;

namespace SuMovie.Context
{
    public class ImdbDbContext : DbContext
    {
        public ImdbDbContext(DbContextOptions<ImdbDbContext> options) : base (options){
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<PersonMovie>()
                .HasKey(x => new { x.MovieId, x.PersonId });
        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<User> Users{get;set;}
        public DbSet<WatchedMovie> WatchedMovies{get;set;}

        public IQueryable<Movie> selectAllMovies(){
            return Movies
                .Include(m => m.Stars);
        }

        public IQueryable<User> selectAllUsers(){
            return Users
                .Include(u => u.WatchedMovies)
                .ThenInclude(u => u.Movie);
        }

        public bool saveAllUsersToCSV(){
            IQueryable<MovieRating> WM = WatchedMovies
                .Include(w => w.User)
                .Include(w => w.Movie)
                .Select(x => new MovieRating
                    {
                        Id = x.Id,
                        MovieId = x.Movie.Id,
                        UserId = x.User.Id,
                        Label = x.Score,
                        Title = x.Movie.Title,
                        Rate = x.Movie.Rate,
                        MetaScore = x.Movie.MetaScore

                    });

            using (var parser = new ChoCSVWriter<MovieRating>(Path.Combine(Environment.CurrentDirectory, "Data", "recommendation-ratings-train.csv")))
            {
                parser.Write(WM);
            }

            this.SaveChanges();

            return true;
        }
        

        public User getUserById(int id){
            return Users
                .Where(u => u.Id == id)
                .Include(u => u.WatchedMovies)
                .ThenInclude(u => u.Movie)
                .First();
        }

        public User login(string username, string passwordHash){
            return Users.Where(u => u.Username == username && u.PasswordHash == passwordHash).FirstOrDefault();
        }

        public User registerUser(User user){
            Users.Add(user);
            this.SaveChanges();

            return user;
        }

        public User watchedMovie(int uId, int mId, int scr){
            User usr = Users.Where(u => u.Id == uId).FirstOrDefault();
            Movie mvi = Movies.Where(m => m.Id == mId).FirstOrDefault();

            if(usr.WatchedMovies == null)
                usr.WatchedMovies = new List<WatchedMovie>();

            WatchedMovie wmvi = new WatchedMovie(mvi, scr);

            WatchedMovies.Add(wmvi);
            this.SaveChanges();

            
            System.Console.WriteLine(wmvi);

            usr.WatchedMovies.Add(wmvi);

            this.SaveChanges();

            return usr;

        }

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