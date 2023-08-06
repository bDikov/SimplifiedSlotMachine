using System;

namespace SimplifiedSlotMachine.Common.Services
{
    public class Writer : IWriter
    {
        public void WriteLine(string input) => Console.WriteLine(input);

        public void WriteLine() => Console.WriteLine();
    }
}