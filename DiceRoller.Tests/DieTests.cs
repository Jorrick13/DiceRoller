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
            var die = new PCL.Die(6);

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
            var die = new PCL.Die(12, 3);

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

        //[Test]
        //public void PositiveModifierTest()
        //{
        //    var die = new PCL.Die(6, modifier: 4);

        //    var results = new System.Collections.Generic.List<int>();

        //    int count = 0;

        //    while (count++ < 10000)
        //    {
        //        die.Roll();
        //        results.Add(die.currentValue);
        //    }

        //    Assert.AreEqual(10, results.Max());
        //    Assert.AreEqual(5, results.Min());
        //}

        //[Test]
        //public void NegativeModifierTest()
        //{
        //    var die = new PCL.Die(6, modifier: -1);

        //    var results = new System.Collections.Generic.List<int>();

        //    int count = 0;

        //    while (count++ < 10000)
        //    {
        //        die.Roll();
        //        results.Add(die.currentValue);
        //    }

        //    Assert.AreEqual(5, results.Max());
        //    Assert.AreEqual(0, results.Min());
        //}




    }
}
