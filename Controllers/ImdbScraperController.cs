using System;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using SuMovie.Models;
using SuMovie.Tools;
using SuMovie.Context;

namespace SuMovie.Controllers{
    [ApiController]
    [Route("[controller]")]

    public class ImdbScraperController : ControllerBase{

        private readonly ILogger<ImdbScraperController> _logger;
        private readonly ImdbScraper _imdbScraper;
        private readonly ImdbDbContext _dbContext;

        public ImdbScraperController(ILogger<ImdbScraperController> logger, ImdbScraper imdbScraper, ImdbDbContext dbContext)
        {
            _logger = logger;
            _imdbScraper = imdbScraper;
            _dbContext = dbContext;
        }
        [HttpGet]
        public List<Movie> Get() {
            return _dbContext.getAllMovies();
        }

        [HttpGet("updateDatabase")]
        public List<Movie> UpdateDatabase(){

            return _dbContext.addManyMovies(_imdbScraper.GetMoviesFromImdb().Result);
        }
    }

}