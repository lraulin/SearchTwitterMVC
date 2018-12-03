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
            var indexViewModel = new IndexViewModel();
            return View(indexViewModel);
        }

        [HttpPost]
        public ViewResult SearchResults(IndexViewModel searchParams)
        {
            Auth.SetCredentials(MyCredentials.GenerateCredentials());

            SearchTweetsParameters searchTweetsParameters = new SearchTweetsParameters(searchParams.Query)
            {
                SearchType = searchParams.Type,
                MaximumNumberOfResults = searchParams.MaxResults
            };

            if (searchParams.HasLocation)
            {
                searchTweetsParameters.GeoCode.Coordinates.Latitude = searchParams.Lat;
                searchTweetsParameters.GeoCode.Coordinates.Longitude = searchParams.Long;
                // TODO: only miles for now...
                searchTweetsParameters.GeoCode.DistanceMeasure = DistanceMeasure.Miles;
            }

            var matchingTweets = Search.SearchTweets(searchTweetsParameters);

            if (searchParams.HasLocation)
                matchingTweets = matchingTweets.Where(p => p.Coordinates != null || !p.CreatedBy.Location.IsNullOrEmpty());

            // Store the search results in TweetRepository so they are available application-wide.
            if (!TweetRepository.SearchResults.IsNullOrEmpty())
                TweetRepository.SearchResults.Clear();

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