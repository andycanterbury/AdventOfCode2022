// See https://aka.ms/new-console-template for more information

var fileData = Utilities.InputLoader.LoadFile("data.txt");

var total = 0;
foreach (var rucksack in fileData)
{
    var size = rucksack.Length;
    var compartment1 = rucksack.Substring(0, size/2);
    var compartment2 = rucksack.Substring(size/2);

    foreach(var itemType in compartment1)
    {
        if (compartment2.Contains(itemType))
        {
            var value = ((short)itemType);
            if (value > 96)
            {
                value -= 96;
            } 
            else 
            { 
                value -= 38; 
            }
            total += value;
            break;
        }
    }
}

Console.WriteLine(total);


total = 0;

for (int i = 0; i < fileData.Length; i += 3)
{
    var sack1 = fileData[i];
    var sack2 = fileData[i+1];
    var sack3 = fileData[i+2];

    foreach(var itemType in sack1)
    {
        if (sack2.Contains(itemType) && sack3.Contains(itemType))
        {
            var value = ((short)itemType);
            if (value > 96)
            {
                value -= 96;
            }
            else
            {
                value -= 38;
            }
            total += value;
            break;
        }
    }
}

Console.WriteLine(total);