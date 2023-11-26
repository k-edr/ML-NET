//Знайти аномалію по дням місяця(1-31 число). Аномалію має показати 7 го числа і 22 числа.
//Для цього потрібно перетворити дані у вигляд День:сума кількості орендування велосипедів. Після чого, якось вчити

using Lab4.Data;
using Lab4.ML;
using Lab4.ML.Models;
using Microsoft.ML;

var rawModels = BikeShareLoader.Load("Data\\bike_sharing_daily.csv").Where(x=>x.Season == 3);

var models = new List<DayBikeShareModel>();

foreach (var model in rawModels)
{
    models.Add(new DayBikeShareModel() 
    { 
        Day = model.Dteday.Day,
        ShareCount = model.Count 
    });
}

new SpikeDetection().DetectSpike(31, models);
