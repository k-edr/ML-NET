using Lab2Try2.Loading;
using Lab2Try2.ML.Models;
using Lab2Try2.ML.Prediction;
using Lab2Try2.ML.Training.Classification;

string dataPath = "Data\\covid-liver.csv";
string modelPath = "MLModels\\SdcaNonCalibrated_CancerModelClassification.mlm";

var rawModels = CancerModelLoader.LoadFromFile(dataPath, ",");
var models = CancerModelLoader.ConvertFromRawToMLModel(rawModels);

var prepandemic = models.Select(x => x).Where(x => x.Year.Equals("Prepandemic")).ToList();
var pandemic = models.Select(x => x).Where(x => x.Year.Equals("Pandemic")).ToList();

//new AveragedPerceptronTrainer().Train(models, modelPath);

var prepandemicPrediction = new Predictor<CancerModel, CancerModelPrediction>().Predict(prepandemic, modelPath);
var pandemicPrediction = new Predictor<CancerModel, CancerModelPrediction>().Predict(pandemic, modelPath);

var preScore = Math.Abs(prepandemicPrediction.Sum(x => x.Score) / prepandemicPrediction.Count);
var panScore = Math.Abs(pandemicPrediction.Sum(x => x.Score) / pandemicPrediction.Count);

Console.WriteLine($"Prepandemic score: {preScore}");
Console.WriteLine($"Pandemic score: {panScore}");
Console.WriteLine($"Difference: {preScore - panScore}");

