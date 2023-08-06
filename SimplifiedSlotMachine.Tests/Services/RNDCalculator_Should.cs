using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimplifiedSlotMachine.Services.Providers;
using System;


namespace SimplifiedSlotMachine.Tests.Services
{
    [TestClass]
    public class RNDCalculator_Should
    {
        [TestMethod]
        public void CalculateCurrentBalance()
        {
            var rndCalculator = new RNDCalculator();
            var expected = rndCalculator.CalculateCurrentBalance(200, 10, 20);
            Assert.AreEqual(expected, 210);
        }

        [TestMethod]
        public void CalculateWinCoeficient_A()
        {
            var rndCalculator = new RNDCalculator();
            var expected = rndCalculator.CalculateWinCoeficient(new int[] { 45, 45, 45 });
            Assert.AreEqual(expected, 1.2M);
        }

        [TestMethod]
        public void CalculateWinCoeficient_P()
        {
            var rndCalculator = new RNDCalculator();
            var expected = rndCalculator.CalculateWinCoeficient(new int[] { 15, 15, 15 });
            Assert.AreEqual(expected, 2.4M);
        }

        [TestMethod]
        public void CalculateWinCoeficient_B()
        {
            var rndCalculator = new RNDCalculator();
            var expected = rndCalculator.CalculateWinCoeficient(new int[] { 35, 35, 35 });
            Assert.AreEqual(expected, 1.8M);
        }      

        [TestMethod]
        public void CalculateWinCoeficient_Wild()
        {
            var rndCalculator = new RNDCalculator();
            var expected = rndCalculator.CalculateWinCoeficient(new int[] { 5, 15, 5 });
            Assert.AreEqual(expected, 0.8M);
        }

        [TestMethod]
        public void GetGameNumbers()
        {
            var rndCalculator = new RNDCalculator();
            var sut = rndCalculator.GetGameNumbers(new int[] { 4, 79, 25 });
            var expected = new int[] { 5, 45, 15 };
            for (int i = 0; i < sut.Length; i++)
            {
                Assert.AreEqual(sut[i], expected[i]);
            }
        }

        [TestMethod]
        public void ContainsDuplicates_False()
        {
            var rndCalculator = new RNDCalculator();
            var sut = rndCalculator.ContainsDuplicates(new int[] { 5, 45, 15 });
            Assert.AreEqual(false,sut);            
        }

        [TestMethod]
        public void ContainsDuplicates_True()
        {
            var rndCalculator = new RNDCalculator();
            var sut = rndCalculator.ContainsDuplicates(new int[] { 5, 45, 45 });

            Assert.AreEqual(true, sut);

        }

    }
}
