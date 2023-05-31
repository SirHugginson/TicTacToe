using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    // Class for the display of the game rules
    internal class Rules
    {
        // This method shows the rules of the game
        // Rules are slit into sections and the user has to press a button to continue to the next section
        public static void DisplayRules()
        {
            // States teh basic outline of the game rules
            Console.WriteLine();
            Console.WriteLine("The aim of this game is to get 3 of the same symbol in a line.");
            Console.WriteLine("Each player will take it in turns to place a symbol.");
            Console.WriteLine("These symbols will be either an X or an O.");
            Console.Write("Press to continue ");
            Console.ReadLine();

            // Shows an exapmle of user messages with an example array
            Console.WriteLine();
            Console.WriteLine("Below is an example of the game board with numbers instead of a background");
            Board.DrawArray("example");
            Console.WriteLine("Player 1 will then reciece the following messages:");
            Console.WriteLine($"    Player 1, enter the X coordinate of your placement. (1 to 3) ");
            Console.WriteLine($"    Player 1, enter the Y coordinate of your placement. (1 to 3) ");
            Console.Write("Press to continue ");
            Console.ReadLine();

            // Displays trhe changes if the user entered an exaple set of coordinates
            Console.WriteLine();
            Console.WriteLine("When the user enters the numbers the board will change at that coordinate.");
            Console.WriteLine("If they entered 1 for X and 1 for Y then the board would look like this:");
            Board.ExampleBoard[0, 0] = " X ";
            Board.DrawArray("example");
            Console.Write("Press to continue ");
            Console.ReadLine();

            // Displays another example placement for clarity
            Console.WriteLine("If the other player then entered 3 for X and 3 for Y then the board would look like this:");
            Board.ExampleBoard[2, 2] = " O ";
            Board.DrawArray("example");
            Console.Write("Press to continue");
            Console.ReadLine();

            // Informs the user that numbers are only the background in the example
            Console.WriteLine();
            Console.WriteLine("In the main game the background of each board coordinate will be: @ ");
            Console.Write("Press to continue");
            Console.ReadLine();
            Console.WriteLine();

            // Resets the board in case of reusing the rukles method
            Board.ExampleBoard[0, 0] = " 1 ";
            Board.ExampleBoard[2, 2] = " 9 ";
        }
    }
}
