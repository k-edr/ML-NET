using CsvHelper;
using Lab3.ML.Models;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Common
{
    class ResolutionTweetLoader
    {
        public static ICollection<ResolutionTweet> LoadTweetsFromFile(string path)
        {
            var tweets = new List<ResolutionTweet>();

            using (StreamReader reader = new StreamReader(path))
            {
                reader.ReadLine();//skip headers

                while (!reader.EndOfStream)
                {
                    var data = reader.ReadLine()!.Split(";");
                    tweets.Add(new ResolutionTweet()
                    {
                        ResolutionTopics = GetValueOrNaN(data[0]),
                        Gender = GetValueOrNaN(data[1]),
                        Name = GetValueOrNaN(data[2]),
                        ResolutionCategory = GetValueOrNaN(data[3]),
                        RetweetCount = GetValueOrNaN(data[4]),
                        Text = GetValueOrNaN(data[5]),
                        TweetCoord = GetValueOrNaN(data[6]),
                        TweetCreated = GetValueOrNaN(data[7]),
                        TweetDate = GetValueOrNaN(data[8]),
                        TweetId = GetValueOrNaN(data[9]),
                        TweetLocation = GetValueOrNaN(data[10]),
                        TweetState = GetValueOrNaN(data[11]),
                        UserTimeZone = GetValueOrNaN(data[12]),
                        TweetRegion = GetValueOrNaN(data[13])
                    });
                }
            }
            return tweets;
        }

        private static string GetValueOrNaN(string data)
        {
            if (string.IsNullOrEmpty(data) || string.IsNullOrWhiteSpace(data))
            {
                return "NaN";
            }
            else
            {
                return data;
            }
        }

        public static ICollection<string> LoadStringByNames(string path)
        {
            var result = new List<string>();

            using (var reader = new StreamReader(path))
            {
                string str = string.Empty;

                int couter = 0;

                while (!reader.EndOfStream)
                {
                    char c = (char)reader.Read();

                    if(c == ';')
                    {
                        couter++;
                    }

                    if((str.Contains(";South") || str.Contains(";West") || str.Contains(";Northeast") || str.Contains(";Midwest")|| str.Contains(";tweet_region")) && couter >= 14)
                    {
                        result.Add(str);
                        str = string.Empty;
                        couter = 0;
                    }
                    else
                    {
                        str += c;
                    }
                    
                }

                return result;
            }
        }

        public static ICollection<string> LoadString(string path)
        {
            var result = new List<string>();

            using (var reader = new StreamReader(path))
            {
                int sepCount = 0;

                StringBuilder builder = new StringBuilder();

                while (!reader.EndOfStream)
                {
                    char c = (char)reader.Read();
                    if (sepCount == 14)
                    {
                        result.Add(builder.ToString());

                        builder.Clear();

                        sepCount = 0;
                    }
                    else if (c == ';')
                    {
                        sepCount++;
                    }
                    builder.Append(c);
                }

                return result;
            }
        }
    }
}
