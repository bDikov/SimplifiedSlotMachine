using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimplifiedSlotMachine.Services.Providers;
using System;
namespace SimplifiedSlotMachine.Tests.Services
{
    [TestClass]
    public class RequestTranslator_Should
    {
        [TestMethod]
        public void Parse_ReturnParams()
        {
            var prs = new RequestTranslator();
            var expected = prs.Parse("200  10");
            Assert.AreEqual(expected.Length, 2);
            Assert.AreEqual(expected[0], "200");
            Assert.AreEqual(expected[1], "10");
        }

        [TestMethod]
        public void Parse_Exception()
        {
            var prs = new RequestTranslator();

            var ex = Assert.ThrowsException<ArgumentOutOfRangeException>(() => prs.Parse("200 "));
            Assert.AreEqual("Specified argument was out of the range of valid values. (Parameter 'Input require exactly 2 params: Initial Balance and Bet Amount.')", ex.Message);
        }
    }

}
