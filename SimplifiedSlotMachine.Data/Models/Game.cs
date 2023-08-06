using System;
using System.Text;

namespace SimplifiedSlotMachine.Data.Models
{
    public class Game
    {
        private decimal balance;
        public decimal Bet { get; set; }

        public decimal Balance { get; set; }

        public decimal RoundDifference { get; set; }

        public Game(decimal balance, decimal bet)
        {
            if (balance < bet)
            {
                throw new ArgumentOutOfRangeException("Bet can not be bigger than balance!");
            }
            this.Balance = balance;
            this.Bet = bet;
        }
    }
}