using SimplifiedSlotMachine.Common;
using SimplifiedSlotMachine.Services.Contracts;
using System;
using System.Linq;

namespace SimplifiedSlotMachine.Services.Providers
{
    public class RequestTranslator : IRequestTranslator
    {
        public string[] Parse(string commandLine)
        {
            var characteristics = commandLine
               .Trim()
               .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (characteristics.Count() != 2)
            {
                throw new ArgumentOutOfRangeException(GlobalMessages.MissingParams);
            }
            return characteristics;
        }
    }
}