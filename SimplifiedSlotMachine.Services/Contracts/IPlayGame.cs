using SimplifiedSlotMachine.Common.Services;
using SimplifiedSlotMachine.Data.Models;

namespace SimplifiedSlotMachine.Services.Contracts
{
    public interface IPlayGame
    {
        string Play(Game model, IRNDCalculator calculator, IGenerator generator, IWriter writer);
    }
}