using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AngleSharp;
using AngleSharp.Dom;

using Microsoft.Extensions.DependencyInjection;

using SuMovie;
using SuMovie.Models;
using SuMovie.Context;

namespace SuMovie.Tools
{
    public static class ServiceCollectionExtensions{
        public static IServiceCollection AddAngleSharp(this IServiceCollection services) =>
            services.AddSingleton(BrowsingContext.New(
                AngleSharp.Configuration.Default.WithDefaultLoader()));
    }
    public class ImdbScraper{

        readonly IBrowsingContext _browsingContext;

		public ImdbScraper(IBrowsingContext browsingContext)
		{
			this._browsingContext = browsingContext;
		}

        private List<Movie> ToMovie(IHtmlCollection<IElement> listerItemList){
            List<Movie> list = new List<Movie>();

            foreach(IElement element in listerItemList){

                IElement link = element.QuerySelector("h3 a");

                if(link!=null){

                    IElement metascoreElement = element.QuerySelector(".metascore");//.klasa; #i; <h1> - html - h1; 
                    IHtmlCollection<IElement> starsElement = element.QuerySelectorAll("p a");

                    String title = link.TextContent;
                    String rate = element.QuerySelector("strong").TextContent;

                    IElement genreTag = element.QuerySelector(".genre");

                    String genres = genreTag.TextContent;

                    List<Person> stars = new List<Person>();

                    int metascore = -1;

                    foreach(IElement starElement in starsElement){
                        String actor = starElement.TextContent;
                        stars.Add(new Person(actor));
                    }

            
                    if(metascoreElement!=null){
                        if(int.TryParse(metascoreElement.Text(), out metascore))
                            Console.WriteLine(metascore);
                        else
                            Console.WriteLine("no way!");
                    }
                
                    list.Add(new Movie(title, stars, genres, DateTime.Now, rate, metascore));
                }
            }

            return list;
        } 

        public async Task<List<Movie>> GetMoviesFromImdb(){
            var htmlDocs = await _browsingContext.OpenAsync("https://www.imdb.com/search/title/?groups=top_250&sort=user_rating,desc&start=0");
            var listerItemList = htmlDocs.QuerySelectorAll(".lister-item-content");

            List<Movie> list = ToMovie(listerItemList);



            return list;
        }
    }
    
}