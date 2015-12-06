using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Games;

namespace GameTests
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void CreateDefaultGame()
        {
            DefaultGame defaultGame = new DefaultGame();
            defaultGame.Shuffle();
            defaultGame.Deal(3);
            Assert.AreEqual(3, defaultGame.Hands.Count);
        }
    }
}
