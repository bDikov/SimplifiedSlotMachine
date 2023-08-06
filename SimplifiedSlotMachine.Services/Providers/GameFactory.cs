using SimplifiedSlotMachine.Data.Models;
using SimplifiedSlotMachine.Services.Contracts;
using SimplifiedSlotMachine.Common.Validators;
using System.Linq;

namespace SimplifiedSlotMachine.Services.Providers
{
    public class GameFactory : IFactory
    {
        public Game Create(string[] commands)
        {
            commands.ToList().ForEach(command => command.IsValidInput());

            var balance = decimal.Parse(commands[0]);
            var bet = decimal.Parse(commands[1]);
            return new Game(balance, bet);
        }
    }
}