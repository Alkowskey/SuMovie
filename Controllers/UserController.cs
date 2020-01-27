using System.Linq;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using SuMovie.Models;
using SuMovie.Tools;
using SuMovie.Context;
using SuMovie;

namespace SuMovie.Controllers{
    [ApiController]
    [Route("[controller]")]

    public class UserController : ControllerBase{

        private readonly ILogger<UserController> _logger;
        private readonly ImdbDbContext _dbContext;
        private readonly IMovieRecommender _movieRecommender;

        public UserController(ILogger<UserController> logger, ImdbScraper imdbScraper, ImdbDbContext dbContext, IMovieRecommender movieRecommender)
        {
            _logger = logger;
            _dbContext = dbContext;
            _movieRecommender = movieRecommender;
        }

        [HttpGet("getAll")]

        public IQueryable<User> getAll(){
            return _dbContext.selectAllUsers();
        }

        [HttpGet("getUser")]
        public User getUser(int id){

            return _dbContext.getUserById(id);
        }

        [HttpGet("notWatchedMovies")]
        public List<Movie> notWatchedMovies(int uId){
            return _dbContext.notWatchedMovies(uId);
        }

        [HttpGet("addWatchedMovie")]
        public User watchedMovie(int uId, int mId, int scr){

            return _dbContext.watchedMovie(uId, mId, scr);
        }

        [HttpPost("register")]
        public User registerUser(User user){
            user.PasswordHash = PasswordHasher.getHashSha256(user.PasswordHash);
            return _dbContext.registerUser(user);
        }
        //Login need to be changed to POST
        [HttpPost("Login")]
        public User login(User user){
            user.PasswordHash = PasswordHasher.getHashSha256(user.PasswordHash);
            return _dbContext.login(user.Username, user.PasswordHash);
        }
        [HttpGet("GetWatchedMovies")]
        public List<Movie> WatchedMoviesUser(int uId){
            return _dbContext.selectWatchedMovies(uId);
        }

        [HttpGet("Save")]
        public string test(){
            _dbContext.saveAllUsersToCSV();

            return "Saved";
        }

        [HttpGet("Prediction")]
        public List<Movie> Prediction(int uId){
            List<Movie> moviesToWatch = new List<Movie>();
            for (int i = 0; i < 50; i++)
            {
                if (_movieRecommender.UseModelForSinglePrediction(uId, i))
                {
                    moviesToWatch.Add(_dbContext.findMovieById(i));
                }
            }

            List<Movie> watched = _dbContext.selectWatchedMovies(uId);

            return moviesToWatch.Except(watched).ToList();
        }
    }

}