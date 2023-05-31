using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    // Class for creating players
    internal class Player
    {
        private string symbol = " X ";
        private int playerNum;
        private bool person;

        // Create objects for players
        public Player(string icon, bool human, int num)
        {
            Symbol = icon;
            Person = human;
            PlayerNum = num;
        }

        // Getters and setters used to assign and retrieve data values
        public string Symbol { 
            get { return symbol; }
            set
            {
                symbol = value;
            }
        }

        public int PlayerNum
        {
            get { return playerNum; }
            set
            {
                playerNum = value;
            }
        }

        public bool Person
        {
            get { return person; }
            set
            {
                person = value;
            }
        }
    }
}
