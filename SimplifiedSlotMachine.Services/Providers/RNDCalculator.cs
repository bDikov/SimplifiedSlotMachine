using SimplifiedSlotMachine.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimplifiedSlotMachine.Services.Providers
{
    public class RNDCalculator : IRNDCalculator
    {
        /* Dictunary with key for each symbol in the game and COEFFICIENT Value. We could use config or table in DB if we want to make it better
         WILD_CARD_KEY = 5;
        APPLE_KEY = 15;
        BANANA_KEY = 35;
        PINEAPPLE_KEY = 45; */

        private readonly Dictionary<int, decimal> kvp = new Dictionary<int, decimal>()
        {   { 5, 0M },
            { 15, 0.8M },
            { 35, 0.6M },
            { 45, 0.4M }
        };

        public decimal CalculateCurrentBalance(decimal balance, decimal stakeAmount, decimal totalWin)
        {
            decimal currentBalance = balance + totalWin - stakeAmount;
            return Math.Round(currentBalance, 2);
        }

        public int[] GetGameNumbers(int[] n)
        {
            var gameRDMNumbers = new int[n.Length];
            for (int i = 0; i < gameRDMNumbers.Length; i++)
            {
                gameRDMNumbers[i] = kvp.Keys
                .OrderBy(x => Math.Abs(x - n[i]))
                .First();
            }

            return gameRDMNumbers;
        }

        public decimal CalculateWinCoeficient(int[] roundCombination)
        {
            decimal win = 0;
            foreach (var number in roundCombination)
            {
                switch (number)
                {
                    case 15:
                        win += this.kvp[15];
                        break;

                    case 35:
                        win += this.kvp[35];
                        break;

                    case 45:
                        win += this.kvp[45];
                        break;

                    default:
                        win += this.kvp[5];
                        break;
                }
            }

            return win;
        }

        public bool ContainsDuplicates(int[] a)
        {
            var countWild = a.Where(x => x == 5).Count();
            var equals = 1;
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = i + 1; j < a.Length; j++)
                {
                    if (a[i] == a[j])
                    {
                        equals++;
                    }
                    else
                    {
                        if (countWild + equals == 3)
                        {
                            return true;
                        }
                    }
                }
            }
            if (equals + countWild >= 3)
            {
                return true;
            }
            return false;
        }
    }
}