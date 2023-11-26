/*
 * Варіант 10. Вплив Covid-19 на захворювання.
 * Вірус змінив життя багатьох людей від початку пандемії. Досліджуються наслідки впливу Covid-19 на здоров'я людей.
 * Одним з таких досліджень є вплив на захворювання печінки. Побудувати модель оцінки впливу пандемії COVID-19 на пацієнтів із
 * вперше діагностованим раком печінки. В якості набору даних можна використати
 * https://www.kaggle.com/datasets/fedesoriano/covid19-effect-on-liver-cancer-prediction- dataset або використати власний набір даних.
 */

//Порівняти допандимійні показники з після пандимійними
/*НЕ ПРАЦЮЄ*/
/*НЕ ПРАЦЮЄ*/
/*НЕ ПРАЦЮЄ*/
/*НЕ ПРАЦЮЄ*/
/*НЕ ПРАЦЮЄ*/
/*НЕ ПРАЦЮЄ*/
using Lab2.Data;
using Lab2.ML;
using Lab2.ML.Models;

var models = CancerModelLoader.LoadFromFile("Data\\covid-liver.csv", ",").ToList();

//DataSummary.ShowNullVariables(models);

string modelPath = "MLModels/CancerModel.zip";

new Trainer().Train(models, modelPath);

var result = new Predictor().Predict(models, modelPath).ToList();


var t = 0;
var f = 0;

for (int i = 0; i < models.Count; i++)
{
    if (result[i] == true) t++;
    else f++;
    //Console.WriteLine($"Original: {models[i].Cancer}");
    //Console.WriteLine($"Predicted: {result[i]}");
    //Console.WriteLine();
}

Console.WriteLine(t);
Console.WriteLine(f);