using System.Collections.Generic;
using Tweetinvi.Models;

namespace SearchTwitterMVC.Models
{
    public static class TweetRepository
    {
        public static Dictionary<double, ITweet> SearchResults { get; set; } = new Dictionary<double, ITweet>();
        public static ITweet SelectedTweet { get; set; }
    }
}