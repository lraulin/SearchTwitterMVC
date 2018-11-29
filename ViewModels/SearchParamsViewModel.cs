using System;
using System.ComponentModel.DataAnnotations;
using Tweetinvi.Models;

namespace SearchTwitterMVC.ViewModels
{
    public class SearchParamsModel
    {
        [Required]
        public string Query { get; set; }
        public SearchResultType Type { get; set; }

        [Range(1, 100)]
        public int MaxResults { get; set; }
    }
}