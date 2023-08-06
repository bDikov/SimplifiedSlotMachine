namespace SimplifiedSlotMachine.Services.Contracts
{
    public interface IGenerator
    {
        int[] Generate(int minRange, int maxRange, int numberOfColomns);
    }
}