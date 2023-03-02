using System;
Console.WriteLine("Made by RoMeRO!");

string userInput;
bool win = false, doublesChecker = false, tripleCheck = false;
int winPoint = 0, losePoint = 0;



//asking for userinput
Console.WriteLine("Enter a word. Make sure all letters are lowercase.");
userInput = Console.ReadLine();
Console.Clear();

//putting the userinput in an array
string[] newName = new string[userInput.Length];


//creating an array for all the letters guessed
string[] guessedLetters = new string[26];
Console.WriteLine("Made by RoMeRO!");
//Another random string array to hold 26 letters
string[] space = new string[26];


//Puts each letter of userinput into the Name array
for (int i = 0; i < userInput.Length; i++)
{
    newName[i] = userInput.Substring(i, 1);
}

//Creating an array for blanks
string[] hiddenWord = new string[userInput.Length];
for (int h = 0; h < userInput.Length; h++)
{
    hiddenWord[h] = "_ ";

}

//Creating array to store wrong guess pictures (different parts of hangman) in
string[] wrongChoices = new string[7];
for (int w = 0; w < 7; w++)
{
    wrongChoices = HangDudes(w);

}
//makes an array to check if guess letter fits 
bool[] checkingGuess = new bool[userInput.Length];



while (win == false && losePoint < 6)
{

    Console.Write("Letters Guessed: ");
    for (int g = 0; g < 6; g++)
    {
        Console.Write(space[g] + " ");
        Console.Write(guessedLetters[g] + "");
    }
    Console.WriteLine();

    Console.WriteLine(wrongChoices[losePoint]);
    for (int s = 0; s < userInput.Length; s++)
    {
        Console.Write(hiddenWord[s]);
    }
    Console.WriteLine();

    string guess = GuessFunction();


    //creating a loop to check all the guesses
    for (int l = 0; l < userInput.Length; l++)
    {
        if (guess == hiddenWord[l])
        {
            doublesChecker = true;
        }
        else if (guess == newName[l])
        {
            tripleCheck = true;
            hiddenWord[l] = guess;
            winPoint++;
            guessedLetters[winPoint] = guess;

        }


        if (winPoint != userInput.Length)
        {
            win = false;
        }
        else
        {
            win = true;
        }


    }
    for (int m = 0; m <= 5; m++)
    {
        if (guess == space[m])
            doublesChecker = true;
    }
    if (tripleCheck == true)
        Console.WriteLine(guess + " fits in.");
    else if (tripleCheck == false)
    {
        Console.WriteLine("not good..");
        losePoint++;
        space[losePoint] = guess;

    }
    else if (doublesChecker == true)
        Console.WriteLine("Double inputted.Please enter another letter.");









}
//Deciding win/lose
if (win == true)
    Console.WriteLine("Pretty sharp. You won!");

else
    Console.WriteLine("Oof, tough luck. The correct answer was: " + newName);
Console.ReadKey();

//function to ask for a guess
static string GuessFunction()
{
    string returnInput;

    Console.WriteLine("Enter a letter(just one): ");
    returnInput = Console.ReadLine().ToLower();
    int check = returnInput.Length;
    while (check > 1)
    {

        Console.WriteLine("More than one letter typed, please try again!");
        Console.Write("> ");
        returnInput = Console.ReadLine().ToLower();
        check = returnInput.Length;
        Console.Clear();
    }
    Console.WriteLine("Made by RoMeRO!");
    return returnInput;

}





static string[] HangDudes(int a)
{
    string[] dudes = { @"
  +---+
  |   |
      |
      |
      |
      |
=========", @"
  +---+
  |   |
  O   |
      |
      |
      |
=========", @"
  +---+
  |   |
  O   |
  |   |
      |
      |
=========", @"
  +---+
  |   |
  O   |
 /|   |
      |
      |
=========", @"
  +---+
  |   |
  O   |
 /|\  |
      |
      |
=========", @"
  +---+
  |   |
  O   |
 /|\  |
 /    |
      |
=========", @"
  +---+
  |   |
  O   |
 /|\  |
 / \  |
      |
=========" };
    return dudes;

}