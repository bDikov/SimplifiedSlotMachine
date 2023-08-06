using System.Numerics;
using System.Reflection;

namespace SimplifiedSlotMachine.Common
{
    public static class GlobalMessages
    {
        internal const string welcomeMessage = "Welcome to TaxCalculator!";
        internal const string enterSalaryMsg = "Enter your gross salary: ";
        internal const string netSalaryResult = "\t" + "Your NET salary is: {0:f2} IDR";

        public const string WelcomeMsg = "Please enter Initial amount and your bet.For Example: 200 10";
        public const string Win = "You have won: {0:f2}";
        public const string EndCmd = "End";
        public const string Balance = "Current balance is: {0:f2}" + "\t";

        public const string GameOver = "Game over" + "\n" + "Do you want to play another game!?" + "\n" + "Enter a balance and your bet, or enter 'end' to close the app" + "\n";
        public const string EnterBet = "Please enter your bet" + "\t";

        //Exception messages
        internal const string InvalidInput = "\t" + "Invalid Balance and/or bet. Please enter valid input!";

        public const string BetBiggerThanBalance = "Please enter bet smaller or equal of your balance.";
        public const string MissingParams = "Input require exactly 2 params: Initial Balance and Bet Amount.";
        public const string InsufficientFunds = "Insufficient funds!";
        internal const string InvalidDecimal = "\t" + "Please enter positive numbers.";
    }
}