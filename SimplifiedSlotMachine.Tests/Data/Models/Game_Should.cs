using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimplifiedSlotMachine.Data.Models;
using System;

namespace SimplifiedSlotMachine.Tests.Data.Models
{
    [TestClass]
    public class Game_Should
    {
        [TestMethod]
        public void CreateGame_WithCorrectData()
        {
            decimal balance = 200M;
            decimal bet = 10;

            var sut = new Game(balance, bet);

            Assert.AreEqual(sut.Bet, bet);
            Assert.AreEqual(sut.Balance, balance);
        }

        [TestMethod]
        public void NOT_CreateGame_WithBetBiggerThanBalance()
        {
            decimal balance = 20;
            decimal bet = 22;

            var ex = Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Game(balance, bet));
            Assert.AreEqual("Specified argument was out of the range of valid values. (Parameter 'Bet can not be bigger than balance!')", ex.Message);
        }
    }
}