using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
                decimal balance = 200M;
                decimal bet = 10;

                var sut = new Game(balance, bet);
            
                Assert.AreEqual(sut.Bet, bet);
                Assert.AreEqual(sut.Balance, balance);
            

        }
    }
}
