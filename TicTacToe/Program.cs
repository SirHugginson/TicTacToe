using System;
using TicTacToe;

// Title screen
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("********************");
Console.WriteLine("* Tic Tac Toe Game *");
Console.WriteLine("********************");
Console.WriteLine();
Console.ForegroundColor = ConsoleColor.White;

string menuSelect;

// Main program loop
do
{
    // Main game menu
    // This allows the user to play TicTacToe against a player or the computer
    Console.WriteLine();
    Console.WriteLine("********************");
    Console.WriteLine("* Select an action *");
    Console.WriteLine("********************");

    Console.WriteLine("1: Play Tic Tac Toe against the computer");
    Console.WriteLine("2: Play Tic Tac Toe against another person");
    Console.WriteLine("3: See the rules of the application");
    Console.WriteLine("9: Quit application");
    Console.Write("Your selection: ");

    // Gets the users choice for the main menu
    menuSelect = Console.ReadLine();


    // Switch statement to run the game in various different scenarios
    // Also allows the user to read the rules of the program
    switch (menuSelect)
    {
        case "1":
            Game.GameRun(true);
            break;
        case "2":
            Game.GameRun(false); 
            break;
        case "3":
            Rules.DisplayRules();
            break;
        case "9": 
            break;
        default:
            Console.WriteLine("Invalid selection. Please try again.");
            break;
    }
} while(menuSelect != "9");

// Message to thge user on program close
Console.WriteLine("Goodbye, Thanks for playing!");