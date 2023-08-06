using SimplifiedSlotMachine.Common;
using SimplifiedSlotMachine.Common.Services;
using SimplifiedSlotMachine.Common.Validators;
using SimplifiedSlotMachine.Data.Models;
using SimplifiedSlotMachine.Services.Contracts;
using System;
using System.Linq;
using System.Text;

namespace SimplifiedSlotMachine.Services.Providers
{
    public class PlayGame : IPlayGame
    {
        private const int ROWS = 4;
        private const int COLS = 3;
        private const int MIN = 0;
        private const int MAX = 100;

        public string Play(Game model, IRNDCalculator calculator, IGenerator generator, IWriter writer)
        {
            var isFirstSpin = true;
            while (model.Balance > 0)
            {
                if (!isFirstSpin)
                {
                    Console.Write(GlobalMessages.EnterBet);

                    string input = Console.ReadLine();
                    try
                    {
                        input.IsValidInput();
                    }
                    catch (Exception ex)
                    {
                        writer.WriteLine(ex.Message);
                        continue;
                    }
                    model.Bet = decimal.Parse(input);
                }
                if (model.Balance < model.Bet)
                {
                    writer.WriteLine(GlobalMessages.BetBiggerThanBalance);
                    continue;
                }

                isFirstSpin = false;
                var balance = model.Balance;
                var bet = model.Bet;
                decimal totalWins = 0;
                if (model.Balance < model.Bet)
                {
                    throw new Exception(GlobalMessages.InsufficientFunds);
                }

                var combinations = new int[ROWS][];

                for (int i = 0; i < ROWS; i++)
                {
                    var currentRow = calculator.GetGameNumbers(generator.Generate(MIN, MAX, COLS));
                    combinations[i] = currentRow;
                    if (calculator.ContainsDuplicates(currentRow))
                    {
                        totalWins += calculator.CalculateWinCoeficient(currentRow);
                    }
                }
                totalWins *= model.Bet;
                model.Balance = calculator.CalculateCurrentBalance(balance, model.Bet, totalWins);
                model.RoundDifference = Math.Round(totalWins, 2);
                string result = string.Join(Environment.NewLine, combinations
                                                        .Select(items => string.Join(" ", items)));

                writer.WriteLine();
                var bldr = new StringBuilder(result);
                bldr.Replace("45", "A");
                bldr.Replace("35", "B");
                bldr.Replace("15", "P");
                bldr.Replace("5", "*");

                writer.WriteLine(bldr.ToString());

                bldr.Clear();

                bldr.AppendLine(string.Format(GlobalMessages.Win, totalWins));
                bldr.AppendLine(string.Format(GlobalMessages.Balance, model.Balance));
                writer.WriteLine(bldr.ToString());
                var x = bldr.ToString();
            }

            return null;
        }
    }
}