using DiceRoller.DiceLogic;
using NUnit.Framework;
using System.Linq;


namespace DiceRoller.Tests
{
 
    [TestFixture]
    public class DieTests
    {
        [Test]
        public void MaxTest()
        {
            var die = new Die(6);

            var results = new System.Collections.Generic.List<int>();

            int count = 0;

            while(count++ < 10000)
            {
                die.Roll();
                results.Add(die.currentValue);
            }

            Assert.AreEqual(6, results.Max());
            Assert.AreEqual(1, results.Min());
        }


        [Test]
        public void MinTest()
        {
            var die = new Die(12, 3);

            var results = new System.Collections.Generic.List<int>();

            int count = 0;

            while (count++ < 10000)
            {
                die.Roll();
                results.Add(die.currentValue);
            }

            Assert.AreEqual(12, results.Max());
            Assert.AreEqual(3, results.Min());
        }

        [Test]
        public void AddTwoDiceTest()
        {
            var die1 = new Die(6, seed: 12345);
            var die2 = new Die(6, seed: 45678);

            die1.Roll();
            die2.Roll();

            Assert.AreEqual(5, die1 + die2);
        }

        [Test]
        public void AddDieAndInt()
        {
            var die1 = new Die(6, seed: 12345);
            die1.Roll();

            Assert.AreEqual(5, die1.currentValue + 4);
        }

        [Test]
        public void AddIntAndDie()
        {
            var die1 = new Die(6, seed: 12345);
            die1.Roll();

            Assert.AreEqual(5, 4 + die1.currentValue);
        }

        [Test]
        public void DieMinusDieTest()
        {
            var die1 = new Die(6, seed: 12345);
            var die2 = new Die(6, seed: 45678);

            die1.Roll();
            die2.Roll();

            Assert.AreEqual(3, die2 - die1);
        }

        [Test]
        public void DieMinusIntTest()
        {
            var die1 = new Die(6, seed: 12345);

            die1.Roll();

            Assert.AreEqual(0, die1.currentValue - 1);
        }

        [Test]
        public void IntMinusDieTest()
        {
            var die1 = new Die(6, seed: 12345);

            die1.Roll();

            Assert.AreEqual(2, 3 - die1.currentValue);
        }

    }
}
