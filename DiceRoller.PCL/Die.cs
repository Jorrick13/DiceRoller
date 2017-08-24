using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiceRoller.PCL
{
    public class Die
    {

#region Properties
        private static Random rand;
        private int seed { get; set; }

        /// <summary>
        /// Minimum value of the die
        /// </summary>
        public int min { get; private set; }
        /// <summary>
        /// Maimum value of the die
        /// </summary>
        public int max { get; private set; }
        /// <summary>
        /// Current value of the die
        /// </summary>
        //public int modifier { get; private set; }
        public int currentValue { get; private set; }


        #endregion Properties

        #region Constructors
        /// <summary>
        /// Constructor for a die
        /// </summary>
        /// <param name="max">Max value of the die</param>
        /// <param name="min">Min value of the die. 1 if not specified</param>
        /// <param name="seed">Seed value for random generator. Random seed if not specified</param>
        public Die(int max, int min = 1, int seed = -1)
        {
            this.min = min;
            this.max = max;
            this.seed = seed;
            //this.modifier = modifier;
            if(seed > 0)
            {
                rand = new Random(seed);
            }
            else
            {
                rand = new Random();
            }
        }


        #endregion Constructors

#region Methods

        /// <summary>
        /// Rolls the die
        /// </summary>
        public void Roll()
        {
            currentValue = rand.Next(min, max + 1);// + modifier;
        }

#endregion Methods

        /// <summary>
        /// Adds the current value of two dice together
        /// </summary>
        /// <param name="die1">The first die</param>
        /// <param name="die2">The second die</param>
        /// <returns>The sum</returns>
        public static int operator +(Die die1, Die die2)
        {
            return die1.currentValue + die2.currentValue;
        }

        /// <summary>
        /// Adds an integer to the current value of a die
        /// </summary>
        /// <param name="die">The die</param>
        /// <param name="value">The value to add</param>
        /// <returns>The sum</returns>
        public static int operator +(Die die, int value)
        {
            return die.currentValue + value;
        }

        /// <summary>
        /// Adds the current value of a die to an integer
        /// </summary>
        /// <param name="value">The value</param>
        /// <param name="die">The die</param>
        /// <returns>The sum</returns>
        public static int operator +(int value, Die die)
        {
            return die + value;
        }

        /// <summary>
        /// Subtracts the current value of two dice
        /// </summary>
        /// <param name="die1">The first die</param>
        /// <param name="die2">The second die</param>
        /// <returns>The difference</returns>
        public static int operator -(Die die1, Die die2)
        {
            return die1.currentValue - die2.currentValue;
        }

        /// <summary>
        /// Subtracts an integer from the current value of a die
        /// </summary>
        /// <param name="die">The die</param>
        /// <param name="value">The value to subtract</param>
        /// <returns>The difference</returns>
        public static int operator -(Die die, int value)
        {
            return die.currentValue - value;
        }

        /// <summary>
        /// Subracts the current value of a die from a integer
        /// </summary>
        /// <param name="value">The value</param>
        /// <param name="die">The die to subract</param>
        /// <returns>The difference</returns>
        public static int operator -(int value, Die die)
        {
            return value - die.currentValue;
        }


    }
}
