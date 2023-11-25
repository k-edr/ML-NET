/*
 * Варіант 10. Аналіз поведінки клієнтів
 * Аналіз поведінки клієнтів дає цінну інформацію про вплив ціни на покупку,
 * ринкові можливості та інші фактори, які впливають на рішення про покупку.
 * Така інформація допомагає роздрібним торговцям і компаніям оптимізувати системи просування та рекомендацій,
 * що, як наслідок, призводить до збільшення товарообігу.
 * Модель регресійних дерев (Приклад https://learn.microsoft.com/en-us/dotnet/api/microsoft.ml.trainers.fasttree.fasttreeregressiontrainer?view=ml-dotnet)
 * може бути використана для реалізації варіанту. Допускається використання інших регресійних моделей.
 * В якості набору даних можна використати https://www.kaggle.com/datasets/cerolacia/black-friday-sales-prediction
 * або використати власний набір даних.
*/
using Lab1.ML.Models;

var str = typeof(PurchaseModel).GetProperties().Select(prop => prop.Name).ToArray();

foreach (var item in str)
{
    Console.WriteLine(item);
}

