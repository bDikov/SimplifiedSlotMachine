namespace SimplifiedSlotMachine.Services.Contracts
{
    public interface IRNDCalculator
    {
        decimal CalculateWinCoeficient(int[] roundCombination);
        decimal CalculateCurrentBalance(decimal balance, decimal stakeAmount, decimal totalWin);
        int[] GetGameNumbers(int[] rndNumbers);
        bool ContainsDuplicates(int[] a);
    }
}
