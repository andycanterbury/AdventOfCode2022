// See https://aka.ms/new-console-template for more information

var fileData = Utilities.InputLoader.LoadFile("data.txt");

var score = 0;
foreach (var game in fileData)
{
    var hands = game.Split(' ');
    var elfHand = hands[0].ToUpper();
    var myHand = hands[1].ToUpper();

    if (myHand == "X")
    {
        score += 1;
        switch (elfHand)
        {
            case "A":
                score += 3; //draw
                break;
            case "B":
                // lose
                break;
            case "C":
                score += 6; //win
                break;
        }

    }
    if (myHand == "Y")
    {
        score += 2;
        switch (elfHand)
        {
            case "A":
                score += 6;//win
                break;
            case "B":
                score += 3;// draw
                break;
            case "C":
                //lose
                break;
        }
    }
    if (myHand == "Z")
    {
        score += 3;
        switch (elfHand)
        {
            case "A":
                //lose
                break;
            case "B":
                score += 6; //win
                break;
            case "C":
                score += 3; //draw
                break;
        }
    }
}

Console.WriteLine(score);


score = 0;
foreach (var game in fileData)
{
    var hands = game.Split(' ');
    var elfHand = hands[0].ToUpper();
    var myHand = hands[1].ToUpper();

    if (myHand == "X") //lose
    {
        switch (elfHand)
        {
            case "A": //I throw scissors
                score += 3; 
                break;
            case "B": //I throw rock
                score += 1;
                break;
            case "C": //I throw paper
                score += 2;
                break;
        }

    }
    if (myHand == "Y") //draw 
    {
        score += 3;
        switch (elfHand)
        {
            case "A": //I throw rock
                score += 1;
                break;
            case "B": //I throw paper
                score += 2;
                break;
            case "C"://I throw scissors
                score += 3;
                break;
        }
    }
    if (myHand == "Z") //win
    {
        score += 6;
        switch (elfHand)
        {
            case "A": //I throw paper
                score += 2;
                break;
            case "B": //I throw scissors
                score += 3;
                break;
            case "C": //I throw rock
                score += 1;
                break;
        }
    }
}

Console.WriteLine(score);