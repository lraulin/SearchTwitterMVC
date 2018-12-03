using System;
using System.ComponentModel.DataAnnotations;
using Tweetinvi.Models;

namespace SearchTwitterMVC.ViewModels
{
    public class IndexViewModel
    {
        [Required]
        public string Query { get; set; }
        public SearchResultType Type { get; set; }

        [Range(1, 100)]
        public int MaxResults { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public int RadiusMiles { get; set; }
        public bool HasLocation { get; set; } = false;
        public bool ShowMap { get; set; } = false;
    }
}