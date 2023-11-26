using CsvHelper.Configuration.Attributes;
using System;
namespace Lab3.ML.Models
{
    class ResolutionTweet
    {
        [Name("resolution_topics")]
        public string? ResolutionTopics { get; set; }

        [Name("gender")]
        public string? Gender { get; set; }

        [Name("name")]
        public string? Name { get; set; }

        [Name("resolution_category")]
        public string? ResolutionCategory { get; set; }

        [Name("retweet_count")]
        public string? RetweetCount { get; set; }

        [Name("text")]
        public string? Text { get; set; }

        [Name("tweet_coord")]
        public string? TweetCoord { get; set; }

        [Name("tweet_created")]
        public string? TweetCreated { get; set; }

        [Name("tweet_date")]
        public string? TweetDate { get; set; }

        [Name("tweet_id")]
        public string? TweetId { get; set; }

        [Name("tweet_location")]
        public string? TweetLocation { get; set; }

        [Name("tweet_state")]
        public string? TweetState { get; set; }

        [Name("user_timezone")]
        public string? UserTimeZone { get; set; }

        [Name("tweet_region")]
        public string? TweetRegion { get; set; }

        public string ToCsvString()
        {
            return $"{ResolutionTopics};{Gender};{Name};{ResolutionCategory};{RetweetCount};{Text};{TweetCoord};{TweetCreated};{TweetDate};{TweetId};{TweetLocation};{TweetState};{UserTimeZone};{TweetRegion}";
        }
    }
}