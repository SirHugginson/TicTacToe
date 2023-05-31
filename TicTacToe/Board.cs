using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    // Class for creating an manipulating the board
    internal class Board
    {
        private static string[,] boardArray = new string[3, 3] {
                { " @ ", " @ ", " @ " },
                { " @ ", " @ ", " @ " },
                { " @ ", " @ ", " @ " }
            };
        private static string[,] exampleBoard = new string[3, 3] {
                { " 1 ", " 2 ", " 3 " },
                { " 4 ", " 5 ", " 6 " },
                { " 7 ", " 8 ", " 9 " }
            };

        // Geters and setters for the different boards that are drawn 
        public static string[,] BoardArray
        {
            get { return boardArray; }
            set
            {
                boardArray = value;
            }
        }

        public static string[,] ExampleBoard
        {
            get { return exampleBoard; }
            set
            {
                exampleBoard = value;
            }
        }

        // Method that is used to write the board to the console
        public static void DrawArray(string arrayChoice)
        {
            string[,] boardToDraw = new string[3, 3];

            // Logic to decide which array is written to the console
            if (arrayChoice == "example") 
            { 
                boardToDraw = ExampleBoard;
            }
            else if (arrayChoice == "game")
            {
                boardToDraw = BoardArray;
            }
            Console.WriteLine();

            // Writes the array to the console
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(boardToDraw[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        // Method that resets the board used ion the main game
        public static void ResetBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    BoardArray[i, j] = " @ ";
                }
            }
        }
    }
}
