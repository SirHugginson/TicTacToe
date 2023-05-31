using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    // Class that defines the main game and the other options on the main menu
    internal class Game
    {
        // Method to create the players of the game
        // Creates a computer player if necessary
        private static (Player, Player) DefinePlayers(bool computer)
        {
            string symbol = string.Empty;
            string userSymbol;
            bool person;
            List<string> symbols = new List<string>
            {
                " X ",
                " O "
            };

            // Checks that the user inputtes symbol is in the symbol list
            // Accepts user input to decide on either X or O
            do
            {
                Console.Write("Enter X or O for player 1: ");
                userSymbol = Console.ReadLine();
                symbol = $" {userSymbol.ToUpper()} ";
            } while (!symbols.Contains(symbol)) ;
            Console.WriteLine($"The Symbol for player 1 is{symbol}");
            symbols.Remove(symbol);
            
            // Defines the first player as an object of the Player class
            Player user1 = new Player(symbol, true, 1);

            // Resets the assignment variables and creates eiother a computer player or human player
            // Player type depends on method parameters
            symbol = symbols[0];
            Console.WriteLine($"The Symbol for player 2 is{symbol}");
            person = !computer;
            Player user2 = new Player(symbol, person, 2);
            return (user1, user2);
        }

        // Method containing the code for a players turn
        private static bool PlayerTurn(Player player1, Player player2, int turnCount)
        {
            // Decides who places on the board
            // Also checks if that player won after their placement
            if (turnCount % 2 == 0)
            {
                PlaceItem.Place(player1);
                return EndChecks.WinCheck(player1);
            }
            else
            {
                PlaceItem.Place(player2);
                return EndChecks.WinCheck(player2);
            }
        }

        // Method that asks the user if they want a rematch
        // The rematch will be with the same player settings defined at the start of the game
        private static int Replay(bool end, int turnCount)
        {
            // Dispay for the end of the game
            if (end)
            {
                // Loop that validates the user input for the replay option
                string replay;
                do
                {
                    Console.Write("Woud you like to play again with the same players? (Y/N) ");
                    replay = Console.ReadLine();
                } while (replay.ToLower() != "y" && replay.ToLower() != "n");

                // Logic check to see if the game is reste with the same settings
                // -1 is returned so the loop increments it to 0 for the start of the next game
                // Returning 8 will end the loop after this check
                if (replay.ToLower() == "y")
                {
                    Board.ResetBoard();
                    Board.DrawArray("game");
                    return -1;
                }
                else if (replay.ToLower() == "n")
                {
                    Board.ResetBoard();
                    return 8;
                }
            }

            // The default case returns the initial turn count
            // this allows the program to continue running
            return turnCount;
        }

        // Method that runs the TicTacToe game
        public static void GameRun(bool computer)
        {
            // Defines some variables that are used throughout the game
            // The end variable is used to determine if the game loop ends
            bool end;

            // The player variable is a Tuple containing 2 player objects
            (Player, Player) player = DefinePlayers(computer);

            // The board is initially drawn to give the users a chance to view the board
            Board.DrawArray("game");

            // A for loop is used so that the game cannot run past 9 turns
            // This is because the board only has 9 cells
            for (int i = 0; i < 9; i++)
            {
                // The end variable iss asigned a value after the player has their turn
                // It takes the current turn number and both player object fromt the tuple
                // These are used to decide who takes their turn
                end = PlayerTurn(player.Item1, player.Item2, i);

                // Draws the updated board after the users have placed a symbol
                Board.DrawArray("game");

                // If the player did not win with their placement this check will check the number of turns
                // If there have been 9 turns without a winner then the game is declared a draw and ends
                if (!end)
                {
                    end = EndChecks.DrawCheck(i);
                }

                // The replay method is called to check if the users want to play again with the same settings
                // If this is the case then the turn counter is reset to start the game again
                i = Replay(end, i);
            }
        }
    }
}
