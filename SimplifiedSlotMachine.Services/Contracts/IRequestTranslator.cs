namespace SimplifiedSlotMachine.Services.Contracts
{
    internal interface IRequestTranslator
    {
        string[] Parse(string commandLine);
    }
}