/* In case MyCredentials.cs needs to be recreated. */

using System;
using Tweetinvi.Models;

namespace SearchTwitterMVC
{
    public static class DummyCreds
    {
        public static string CONSUMER_KEY { get; } = "";
        public static string CONSUMER_SECRET { get; } = "";
        public static string ACCESS_TOKEN { get; } = "";
        public static string ACCESS_TOKEN_SECRET { get; } = "";
        public static string GOOGLE_MAPS_APIKEY { get; } = "";

        public static ITwitterCredentials GenerateCredentials()
        {
            return new TwitterCredentials(CONSUMER_KEY, CONSUMER_SECRET, ACCESS_TOKEN, ACCESS_TOKEN_SECRET);
        }
    }
}