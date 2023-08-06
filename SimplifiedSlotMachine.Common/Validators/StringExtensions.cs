using System;

namespace SimplifiedSlotMachine.Common.Validators
{
    public static class StringExtensions
    {
        public static void IsValidInput(this string input)
        {
            if (!decimal.TryParse(input, out decimal result))
            {
                throw new ArgumentException(GlobalMessages.InvalidInput);
            }
            else if (result <= 0)
            {
                throw new ArgumentException(GlobalMessages.InvalidDecimal);
            }
        }
    }
}