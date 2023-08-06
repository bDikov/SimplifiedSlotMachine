using SimplifiedSlotMachine.Services.Contracts;
using System;

namespace SimplifiedSlotMachine.Services.Providers
{
    public class Generator : IGenerator
    {
        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();

        public int[] Generate(int minRange, int maxRange, int numberOfColomns)
        {
            int[] result = new int[numberOfColomns];

            for (int i = 0; i < numberOfColomns; i++)
            {
                lock (syncLock)
                { // synchronize
                    result[i] = random.Next(minRange, maxRange);
                }
            }

            return result;
        }
    }
}