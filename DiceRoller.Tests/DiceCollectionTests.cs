using System.Linq;
using NUnit.Framework;
using System.Collections.Generic;
using DiceRoller.DiceLogic;

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
            Assert.AreEqual(1, diceCollection.Dice.ElementAt(0).max);
            Assert.AreEqual(2, diceCollection.Dice.ElementAt(1).max);
            Assert.AreEqual(3, diceCollection.Dice.ElementAt(2).max);
            Assert.AreEqual(4, diceCollection.Dice.ElementAt(3).max);

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
        public void GetHighestDefaultValueTest()
        {
            var dice = new List<Die>()
            {
                new Die(6, seed:12345),
                new Die(6, seed:123456),
                new Die(6, seed:1234)
            };

            var diceCollection = new DiceCollection(dice);
            diceCollection.Roll();

            var expectedList = new List<int>()
            {
                6
            };

            CollectionAssert.AreEqual(expectedList, diceCollection.GetHighest());
        }

        [Test]
        public void GetHighestDefaultValueWithDuplicates()
        {
            var dice = new List<Die>()
            {
                new Die(6, seed:123456),
                new Die(6, seed:123456),
                new Die(6, seed:1234)
            };

            var diceCollection = new DiceCollection(dice);
            diceCollection.Roll();

            var expectedList = new List<int>()
            {
                6
            };

            CollectionAssert.AreEqual(expectedList, diceCollection.GetHighest());
        }

        [Test]
        public void GetHighestSpSpecifiedValueTest()
        {
            var dice = new List<Die>()
            {
                new Die(6, seed:12345),
                new Die(6, seed:123456),
                new Die(6, seed:1234)
            };

            var diceCollection = new DiceCollection(dice);
            diceCollection.Roll();

            var expectedList = new List<int>()
            {
                6,
                3
            };

            CollectionAssert.AreEqual(expectedList, diceCollection.GetHighest(2));
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
        public void SumHighestDefaultValueTest()
        {
            var dice = new List<Die>()
            {
                new Die(6, seed:12345),
                new Die(6, seed:123456),
                new Die(6, seed:1234)
            };

            var diceCollection = new DiceCollection(dice);
            diceCollection.Roll();

            Assert.AreEqual(6, diceCollection.SumHighest());
        }

        [Test]
        public void SumHighestDefaultValueTestWithDuplicates()
        {
            var dice = new List<Die>()
            {
                new Die(6, seed:123456),
                new Die(6, seed:123456),
                new Die(6, seed:1234)
            };

            var diceCollection = new DiceCollection(dice);
            diceCollection.Roll();

            Assert.AreEqual(6, diceCollection.SumHighest());
        }

        [Test]
        public void SumHighestSpecifiedValueTest()
        {
            var dice = new List<Die>()
            {
                new Die(6, seed:12345),
                new Die(6, seed:123456),
                new Die(6, seed:1234)
            };

            var diceCollection = new DiceCollection(dice);
            diceCollection.Roll();

            Assert.AreEqual(9, diceCollection.SumHighest(2));
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

        [Test]
        public void AddTwoDiceCollections()
        {
            var diceSet1 = new List<Die>()
            {
                new Die(6, seed: 12345),
                new Die(6, seed: 123456),
                new Die(6, seed: 1234)
            };

            var diceSet2 = new List<Die>()
            {
                new Die(6, seed: 1326),
                new Die(6, seed: 6543),
                new Die(6, seed: 78654)
            };

            var diceCollection1 = new DiceCollection(diceSet1);
            var diceCollection2 = new DiceCollection(diceSet2);

            diceCollection1.Roll();
            diceCollection2.Roll();

            Assert.AreEqual(22, diceCollection1 + diceCollection2);
        }

        [Test]
        public void AddDieToDiceCollectionTest()
        {
            var diceSet1 = new List<Die>()
            {
                new Die(6, seed: 12345),
                new Die(6, seed: 123456),
                new Die(6, seed: 1234)
            };

            var die = new Die(6, seed: 6573);

            var diceCollection = new DiceCollection(diceSet1);

            diceCollection.Roll();
            die.Roll();

            Assert.AreEqual(13, diceCollection + die);
        }

        [Test]
        public void AddDiceCollectionToDieTest()
        {
            var diceSet1 = new List<Die>()
            {
                new Die(6, seed: 12345),
                new Die(6, seed: 123456),
                new Die(6, seed: 1234)
            };

            var die = new Die(6, seed: 6573);

            var diceCollection = new DiceCollection(diceSet1);

            diceCollection.Roll();
            die.Roll();

            Assert.AreEqual(13, die + diceCollection);
        }

        [Test]
        public void AddIntToDiceCollectionTest()
        {
            var diceSet1 = new List<Die>()
            {
                new Die(6, seed: 12345),
                new Die(6, seed: 123456),
                new Die(6, seed: 1234)
            };

            var diceCollection = new DiceCollection(diceSet1);

            diceCollection.Roll();

            Assert.AreEqual(15, diceCollection + 4);
        }

        [Test]
        public void AddDiceCollectiontoIntTest()
        {
            var diceSet1 = new List<Die>()
            {
                new Die(6, seed: 12345),
                new Die(6, seed: 123456),
                new Die(6, seed: 1234)
            };

            var diceCollection = new DiceCollection(diceSet1);

            diceCollection.Roll();

            Assert.AreEqual(15, 4 + diceCollection);
        }

        [Test]
        public void SubtractTwoDiceCollections()
        {
            var diceSet1 = new List<Die>()
            {
                new Die(6, seed: 12345),
                new Die(6, seed: 123456),
                new Die(6, seed: 1234)
            };

            var diceSet2 = new List<Die>()
            {
                new Die(6, seed: 1326),
                new Die(6, seed: 6543),
                new Die(6, seed: 78654)
            };

            var diceCollection1 = new DiceCollection(diceSet1);
            var diceCollection2 = new DiceCollection(diceSet2);

            diceCollection1.Roll();
            diceCollection2.Roll();

            Assert.AreEqual(4, diceCollection1 - diceCollection2);
        }

        [Test]
        public void SubtractDieFromDiceCollectionTest()
        {
            var diceSet1 = new List<Die>()
            {
                new Die(6, seed: 12345), //3
                new Die(6, seed: 123456), //3 
                new Die(6, seed: 1234) //4
            };

            var die = new Die(6, seed: 3376); //1

            var diceCollection = new DiceCollection(diceSet1);

            diceCollection.Roll();
            die.Roll();

            Assert.AreEqual(9, diceCollection - die);
        }

        [Test]
        public void SubtractDiceCollectionFromDie()
        {
            var diceSet1 = new List<Die>()
            {
                new Die(6, seed: 12345), //3
                new Die(6, seed: 123456), //3 
                new Die(6, seed: 1234) //4
            };

            var die = new Die(6, seed: 3376); //1

            var diceCollection = new DiceCollection(diceSet1);

            diceCollection.Roll();
            die.Roll();

            Assert.AreEqual(-9, die - diceCollection);
        }

        [Test]
        public void SubtractIntFromDieCollectionTest()
        {
            var diceSet75 = new List<Die>()
            {
                new Die(6, seed: 12345), //3
                new Die(6, seed: 123456), //6
                new Die(6, seed: 1234) //2
            };

            var diceCollection = new DiceCollection(diceSet75);

            diceCollection.Roll();

            Assert.AreEqual(8, diceCollection - 3);
        }

        [Test]
        public void IntMinusDieCollectionTest()
        {
            var diceSet = new List<Die>()
            {
                new Die(6, seed: 123456),
                new Die(6, seed: 3376)
            };

            var diceCollection = new DiceCollection(diceSet);
            diceCollection.Roll();

            Assert.AreEqual(4, 10 - diceCollection);
        }
    }
}
