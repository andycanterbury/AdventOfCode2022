// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var fileData = Utilities.InputLoader.LoadFile("data.txt");

Console.WriteLine(fileData[0]);
