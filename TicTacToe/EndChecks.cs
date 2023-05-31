using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    // Class that checks to see if a player has won or there is a draw
    internal class EndChecks
    {
        // Checks the columns for 3 consecutive matches
        private static bool ColumnCheck(string icon)
        {
            string checkString1;
            string checkString2;
            string checkString3;

            // For loop that goes through each column
            for (int i = 0; i < 3; i++)
            {
                // The y coordinates of the board are fixed as the columns are the ones being checked
                checkString1 = Board.BoardArray[0, i];
                checkString2 = Board.BoardArray[1, i];
                checkString3 = Board.BoardArray[2, i];

                // Logic that returns true if the columns are a match
                if (checkString1 == icon && checkString2 == icon && checkString3 == icon)
                {
                    return true;
                }
            }

            // Default is to return false
            return false;
        }

        // Checks the rows for 3 consecutive matches
        private static bool RowCheck(string icon)
        {
            string checkString1;
            string checkString2;
            string checkString3;

            // For loop checking each row for a match
            for (int i = 0; i < 3; i++)
            {
                // The x coording=ates are fixed as the rows are veing checked
                checkString1 = Board.BoardArray[i, 0];
                checkString2 = Board.BoardArray[i, 1];
                checkString3 = Board.BoardArray[i, 2];

                // Logic that returns true if a matching row is found
                if (checkString1 == icon && checkString2 == icon && checkString3 == icon)
                {
                    return true;
                }
            }

            // The default returs false
            return false;
        }

        // Checks the diagonals for 3 consecutive matches
        private static bool DiagonalCheck(string icon)
        {
            // Instead of a for loop the options are hard coded in
            // This is an inflexible sdolution but it is quick and easy to implement
            string checkString1 = Board.BoardArray[0, 0];
            string checkString2 = Board.BoardArray[2, 0];
            string checkString3 = Board.BoardArray[0, 2];
            string checkString4 = Board.BoardArray[1, 1];
            string checkString5 = Board.BoardArray[2, 2];

            // This logic returns true if either of the diagonals match
            if ((checkString4 == icon && checkString2 == icon && checkString3 == icon) || (checkString1 == icon && checkString4 == icon && checkString5 == icon))
            {
                return true;
            }

            // If the diagonals do not match false is returned
            return false;
        }

        // Checks to see if a player has won
        public static bool WinCheck(Player player)
        {
            // Combines all of the different checks that return a win
            bool columnCheck = ColumnCheck(player.Symbol);
            bool rowCheck = RowCheck(player.Symbol);
            bool diagonalCheck = DiagonalCheck(player.Symbol);

            // If any of the checks return true then the wincheck method returns true
            if (columnCheck || rowCheck || diagonalCheck)
            {
                Console.WriteLine($"{player.Symbol} is the winner!");
                return true;
            }

            // If nmo checks return truew then the mothod returns false
            return false;
        }

        // This method checks if the game was a draw
        public static bool DrawCheck(int turnCount)
        {
            // If the game has lasted until the 9thb turn then the logic returns true
            // (i=8 on the 9th turn) 
            if (turnCount == 8)
            {
                Console.Write("It's a draw!");
                return true;
            }

            // If the turn is not equal to 8 then there is no draw and false is returned
            return false;
        }
    }
}
