using SimplifiedSlotMachine.Data.Models;

namespace SimplifiedSlotMachine.Services.Contracts
{
    interface IFactory
    {     
        Game Create(string[] commands);
    }
}
