using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimplifiedSlotMachine.Services.Providers;
using Moq;
using SimplifiedSlotMachine.Data.Models;
using System;
using SimplifiedSlotMachine.Services.Contracts;
using SimplifiedSlotMachine.Common.Services;
using System.IO;

namespace SimplifiedSlotMachine.Tests.Services
{
    [TestClass]
    public class PlayGame_Should
    {
        [TestMethod]
        public void Parse_ReturnParams()
        {
            var mockRandom = new Mock<Random>();
            mockRandom.Setup(r => r.Next()).Returns(45);

            var mockCalculator = new Mock<IRNDCalculator>();
            mockCalculator.Setup(c => c.GetGameNumbers(new[] { 35, 35, 35 })).Returns(new[] { 35, 35, 35 });
            mockCalculator.Setup(c => c.ContainsDuplicates(new[] { 35, 35, 35 })).Returns(true);
            mockCalculator.Setup(c => c.CalculateWinCoeficient(new[] { 45, 45, 45 })).Returns(1.2M);
            mockCalculator.Setup(c => c.CalculateCurrentBalance(200, 10, 12)).Returns(202m);
            var generator = new Mock<IGenerator>();
            generator.Setup(g => g.Generate(0, 100, 3)).Returns(new[] { 35, 35, 35 });
            var writer = new Writer();
            var game = new Game(200, 10);
            var play = new PlayGame();

            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            var sut = play.Play(game, mockCalculator.Object, generator.Object, writer);

            string consoleOutput = stringWriter.ToString();
            // Assert
            string text = "\r\nB B B\r\nB B B\r\nB B B\r\nB B B\r\nYou have won: 0.00\r\nCurrent balance is: 0.00\t\r\n\r\n";

            Assert.IsNull(sut);
            Assert.IsNotNull(consoleOutput);
            Assert.AreEqual(consoleOutput.TrimEnd().Normalize(), text.TrimEnd().Normalize());
        }
    }
}