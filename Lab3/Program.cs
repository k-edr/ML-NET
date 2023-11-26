using Lab3.Common;
using Lab3.ML;
using Lab3.ML.Models;

var models = ResolutionTweetLoader.LoadTweetsFromFile(Constants.DATA_PATH).ToList();

//new Trainer().Train(models);

var result = new Predictor().Predict(models).ToList();

result.Sort((left, right) => left.Prediction.ClusterId.CompareTo(right.Prediction.ClusterId));

foreach (var model in result)
{
    Console.WriteLine($"\tClusterId: {model.Prediction.ClusterId},\t Name: {model.Tweet.ResolutionCategory}, \t Text: {model.Tweet.Text}");
}