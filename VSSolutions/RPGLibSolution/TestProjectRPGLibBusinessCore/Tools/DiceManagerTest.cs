using Microsoft.VisualStudio.TestTools.UnitTesting;
using RPGLibBusinessCore.Tools;
using RPGLibEntityCore.Entities;
using System.Collections.Generic;

namespace TestProjectRPGLibBusinessCore
{
    [TestClass]
    public class DiceManagerTest
    {
        [TestMethod]
        public void Roll_With_Two_Dices()
        {
            DiceBase diceOne = new DiceBase() { MinValue = 1, MaxValue = 20, Name = "DiceTest 1" };
            DiceBase diceTwo = new DiceBase() { MinValue = 1, MaxValue = 20, Name = "DiceTest 2" };
            List<DiceBase> dices = new List<DiceBase> { diceOne, diceTwo }; 

            DiceManager diceManager = new DiceManager(dices);

            var result = diceManager.Roll();

            Assert.IsNotNull(diceManager);

            Assert.IsTrue(result.TotalScore>=diceOne.MinValue+diceTwo.MinValue && result.TotalScore<= diceOne.MaxValue + diceTwo.MaxValue);

            result.PlayedDices.ForEach(dice =>
            {
                Assert.IsTrue(dice.CurrentValue >= dice.MinValue && dice.CurrentValue <= dice.MaxValue );
            });

        }
    }
}
