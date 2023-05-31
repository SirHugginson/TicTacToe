using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    // Class that places an item on the board
    internal class PlaceItem
    {
        // Method for aquiring the coodinates for the placement of the X or O
        private static (int, int) GetCoords(Player player)
        {
            int coordX;
            int coordY;
            bool numCheck;
            bool yCheck;
            bool xCheck;

            // User change part of array
            if (player.Person)
            {
                // Loop to validate the user iunput
                do
                {
                    // Asks the user for the coodinates of their placement and assigns them to values
                    Console.Write($"Player {player.PlayerNum}, enter the X coordinate of your placement. (1 to 3) ");
                    string? xAttempt = Console.ReadLine();

                    Console.Write($"Player {player.PlayerNum}, enter the Y coordinate of your placement. (1 to 3) ");
                    string? yAttempt = Console.ReadLine();

                    // These methods check that the user has entered numbers
                    xCheck = int.TryParse(xAttempt, out coordX);
                    yCheck = int.TryParse(yAttempt, out coordY);

                    // These methods check that the user has enteres numbers in the correct range
                    bool xRange = Enumerable.Range(1, 3).Contains(coordX);
                    bool yRange = Enumerable.Range(1, 3).Contains(coordY);

                    // If the user entered numbers in the correct range then the input is taken
                    if (xCheck && yCheck && xRange && yRange)
                    {
                        numCheck = true;
                    }

                    // If not then the user is asked to enter coordinates again
                    else
                    {
                        numCheck = false;
                        Console.WriteLine();
                        Console.WriteLine("Enter 1, 2, or 3 for the coordinates please!");
                        Console.WriteLine();
                    }
                    coordX--;
                    coordY--;
                } while (!numCheck);
            }

            // Computer change part of array
            else
            {
                // the computer will place a symbol at a random coordinate on the board
                Random rand = new Random();
                coordX = rand.Next(0, 3);
                coordY = rand.Next(0, 3);
            }

            return (coordY, coordX);
        }

        // Method to place an item
        public static void Place(Player player)
        {
            // Tuple of integers is the type for the coordinates
            (int, int) coords;
            bool occupied;

            // Loop that validates the coordinates are not already occupied
            do
            {
                coords = GetCoords(player);
                occupied = (Board.BoardArray[coords.Item1, coords.Item2] == " X " || Board.BoardArray[coords.Item1, coords.Item2] == " O ");

                // If the space is occupied and a user entered the coordinates they are told to enter new coords
                if (occupied && player.Person)
                {
                    Console.WriteLine("Coordinates already occupied, pick again!");
                }
            } while (occupied);

            // Informs the user of the coordinates chosen by the computer
            if (!player.Person)
            {
                Console.WriteLine($"The computer will choose {coords.Item2 + 1}, {coords.Item1 + 1}.");
            }

            // Places the valueat the chose coords
            Board.BoardArray[coords.Item1, coords.Item2] = player.Symbol;
        }
    }
}
