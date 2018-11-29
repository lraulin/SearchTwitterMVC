using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SearchTwitterMVC.ViewModels;
using Tweetinvi;
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

            var matchingTweets = Search.SearchTweets(searchTweetsParameters);

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

        public ViewResult TweetMap(double lat, double lng)
        {
            MapViewModel location = new MapViewModel
            {
                Lat = lat,
                Long = lng
            };
            return View(location);
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