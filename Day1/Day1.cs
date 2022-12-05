// See https://aka.ms/new-console-template for more information
var fileData = Utilities.InputLoader.LoadFile("data.txt");

var elfTotal = 0;
int calories = 0;
var maxElfCalories = 0;
foreach(var foodItem in fileData)
{
    if(int.TryParse(foodItem, out calories))
    {
        elfTotal += calories;
    } 
    else
    {
        if (elfTotal >= maxElfCalories)
        {
            maxElfCalories = elfTotal;
        }
        elfTotal = 0;
    }
}

Console.WriteLine(maxElfCalories);


elfTotal = 0;
calories = 0;
var elfCaloriesList = new List<int>();
foreach (var foodItem in fileData)
{
    if (int.TryParse(foodItem, out calories))
    {
        elfTotal += calories;
    }
    else
    {
        elfCaloriesList.Add(elfTotal);
        elfTotal = 0;
    }
}
elfCaloriesList.Add(elfTotal);
var sorted = elfCaloriesList.OrderByDescending(x => x).ToList();
maxElfCalories = sorted[0] + sorted[1] + sorted[2];
Console.WriteLine(maxElfCalories);
