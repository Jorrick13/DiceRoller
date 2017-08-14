using System.Linq;
using NUnit.Framework;
using System.Collections.Generic;
using DiceRoller.PCL;

namespace DiceRoller.Tests
{
    [TestFixture]
    public class DiceCollectionTests
    {
        [Test]
        public void CreateTest()
        {

            var dice = new List<Die>()
            {
                new Die(1),
                new Die(2),
                new Die(3),
                new Die(4)
            };

            var diceCollection = new DiceCollection(dice);

            Assert.AreEqual(4, diceCollection.Dice.Count);
            Assert.AreEqual(2, diceCollection.Dice.ElementAt(0).max);
            Assert.AreEqual(3, diceCollection.Dice.ElementAt(1).max);
            Assert.AreEqual(4, diceCollection.Dice.ElementAt(2).max);
            Assert.AreEqual(5, diceCollection.Dice.ElementAt(3).max);

        }

        [Test]
        public void RollTest()
        {
            var dice = new List<Die>()
            {
                new Die(1),
                new Die(2),
                new Die(3),
                new Die(4)
            };

            var diceCollection = new DiceCollection(dice);

            diceCollection.Roll();

            var count = diceCollection.Dice.Where(d => d.currentValue == 0).Sum(d => d.currentValue);
            Assert.AreEqual(0, count);
        }

        [Test]
        public void SumTest()
        {
            var count = 0;
            var allMin = false;
            var allMax = false;
            var dice = new List<Die>()
            {
                new Die(6),
                new Die(6),
                new Die(6)
            };

            var diceCollection = new DiceCollection(dice);

            while(count++ < 10000)
            {
                diceCollection.Roll();
                if(!allMax && diceCollection.Sum() == 18)
                {
                    allMax = true;
                }
                if(!allMin && diceCollection.Sum() == 3)
                {
                    allMin = true;
                }


                Assert.LessOrEqual(diceCollection.Sum(), 18);
                Assert.GreaterOrEqual(diceCollection.Sum(), 3);

            }
            Assert.True(allMin);
            Assert.True(allMax);
        }

        [Test]
        public void SumTestWithModifier()
        {
            var count = 0;
            var allMin = false;
            var allMax = false;
            var dice = new List<Die>()
            {
                new Die(6),
                new Die(6),
                new Die(6)
            };

            var diceCollection = new DiceCollection(dice, 3);

            while (count++ < 10000)
            {
                diceCollection.Roll();
                if (!allMax && diceCollection.Sum() == 21)
                {
                    allMax = true;
                }
                if (!allMin && diceCollection.Sum() == 6)
                {
                    allMin = true;
                }


                Assert.LessOrEqual(diceCollection.Sum(), 21);
                Assert.GreaterOrEqual(diceCollection.Sum(), 6);

            }
            Assert.True(allMin);
            Assert.True(allMax);
        }

        [Test]
        public void Add2DiceCollectionsTest()
        {

            var count = 0;
            var allMin = false;
            var allMax = false;
            var max = 15 + 18;
            var min = 6;
            var dice1 = new List<Die>()
            {
                new Die(5),
                new Die(5),
                new Die(5)
            };

            var dice2 = new List<Die>()
            {
                new Die(6),
                new Die(6),
                new Die(6),
            };

            var diceCollection1 = new DiceCollection(dice1);
            var diceCollection2 = new DiceCollection(dice2);

            while(count++ < 1000000)
            {
                diceCollection1.Roll();
                diceCollection2.Roll();

                var result = diceCollection1 + diceCollection2;

                if(!allMax && result == max)
                {
                    allMax = true;
                }
                if(!allMin && result == min)
                {
                    allMin = true;
                }

                Assert.LessOrEqual(result, max);
                Assert.GreaterOrEqual(result, min);

            }

            Assert.IsTrue(allMin);
            Assert.IsTrue(allMax);

        }

        [Test]
        public void Add2DiceCollectionsTestOneModifier()
        {

            var count = 0;
            var allMin = false;
            var allMax = false;
            var max = 15 + 18 + 3;
            var min = 6 + 3;
            var dice1 = new List<Die>()
            {
                new Die(5),
                new Die(5),
                new Die(5)
            };

            var dice2 = new List<Die>()
            {
                new Die(6),
                new Die(6),
                new Die(6),
            };

            var diceCollection1 = new DiceCollection(dice1, 3);
            var diceCollection2 = new DiceCollection(dice2);

            while (count++ < 100000)
            {
                diceCollection1.Roll();
                diceCollection2.Roll();

                var result = diceCollection1 + diceCollection2;

                if (!allMax && result == max)
                {
                    allMax = true;
                }
                if (!allMin && result == min)
                {
                    allMin = true;
                }

                Assert.LessOrEqual(result, max);
                Assert.GreaterOrEqual(result, min);

            }

            Assert.IsTrue(allMin);
            Assert.IsTrue(allMax);

        }

        [Test]
        public void Add2DiceCollectionsTestTwoModifier()
        {

            var count = 0;
            var allMin = false;
            var allMax = false;
            var max = 15 + 18 + 3 + 2;
            var min = 6 + 3 + 2;
            var dice1 = new List<Die>()
            {
                new Die(5),
                new Die(5),
                new Die(5)
            };

            var dice2 = new List<Die>()
            {
                new Die(6),
                new Die(6),
                new Die(6),
            };

            var diceCollection1 = new DiceCollection(dice1, 3);
            var diceCollection2 = new DiceCollection(dice2, 2);

            while (count++ < 100000)
            {
                diceCollection1.Roll();
                diceCollection2.Roll();

                var result = diceCollection1 + diceCollection2;

                if (!allMax && result == max)
                {
                    allMax = true;
                }
                if (!allMin && result == min)
                {
                    allMin = true;
                }

                Assert.LessOrEqual(result, max);
                Assert.GreaterOrEqual(result, min);

            }

            Assert.IsTrue(allMin);
            Assert.IsTrue(allMax);

        }
    }
}
