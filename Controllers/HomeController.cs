using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SearchTwitterMVC.Helpers;
using SearchTwitterMVC.Models;
using SearchTwitterMVC.ViewModels;
using Tweetinvi;
using Tweetinvi.Models;
using Tweetinvi.Parameters;

namespace SearchTwitterMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ViewResult SearchResults(SearchParamsModel searchParams)
        {
            Auth.SetCredentials(MyCredentials.GenerateCredentials());

            SearchTweetsParameters searchTweetsParameters = new SearchTweetsParameters(searchParams.Query)
            {
                SearchType = searchParams.Type
            };

            // var matchingTweets = Search.SearchTweets(searchTweetsParameters);

            // Filter to the first 5 results with location data
            var matchingTweets = Search
                .SearchTweets(searchTweetsParameters)
                .Where(p => p.Coordinates != null)
                .Take(5);

            // Store the search results in TweetRepository so they are available application-wide.
            if (!TweetRepository.SearchResults.IsNullOrEmpty())
                TweetRepository.SearchResults.Clear();
            if (!matchingTweets.IsNullOrEmpty())
                foreach (var tweet in matchingTweets)
                    TweetRepository.SearchResults.Add(tweet.Id, tweet);

            return View(matchingTweets);
        }

        [HttpGet]
        public ViewResult Map()
        {
            return View();
        }

        [HttpPost]
        public string Map(MapViewModel mapModel)
        {
            return "Lat: " + mapModel.Lat + "\nLong: " + mapModel.Long;
        }

        public ViewResult TweetMap(double tweetId)
        {
            ITweet tweet = TweetRepository.SearchResults[tweetId];
            return View(tweet);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}