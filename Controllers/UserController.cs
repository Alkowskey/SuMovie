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

        [HttpGet("addWatchedMovie")]
        public User watchedMovie(int uId, int mId, int scr){

            return _dbContext.watchedMovie(uId, mId, scr);
        }

        [HttpPost("register")]
        public User registerUser(User user){
            return _dbContext.registerUser(user);
        }
        //Login need to be changed to POST
        [HttpGet("Login")]
        public User login(string username, string passwordHash){
            return _dbContext.login(username, passwordHash);
        }

        [HttpGet("Save")]
        public string test(){
            _dbContext.saveAllUsersToCSV();

            return "Saved";
        }

        [HttpGet("Prediction")]
        public string Prediction(int uId, int mId){
            return _movieRecommender.UseModelForSinglePrediction(uId, mId);
        }
    }

}