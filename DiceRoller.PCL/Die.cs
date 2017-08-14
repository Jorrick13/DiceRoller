using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiceRoller.PCL
{
    public class Die
    {

        private static Random rand;

        public int min { get; private set; }
        public int max { get; private set; }
        //public int modifier { get; private set; }
        public int currentValue { get; private set; }
        public int seed { get; private set; }


        public Die(int max, int min = 1, int seed = -1)
        {
            this.min = min;
            this.max = max + 1;
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


        public void Roll()
        {
            currentValue = rand.Next(min, max);// + modifier;
        }

        public static int operator +(Die die1, Die die2)
        {
            return die1.currentValue + die2.currentValue;
        }

        public static int operator +(Die die, int value)
        {
            return die.currentValue + value;
        }

        public static int operator +(int value, Die die)
        {
            return die + value;
        }

        public static int operator -(Die die1, Die die2)
        {
            return die1.currentValue - die2.currentValue;
        }

        public static int operator -(Die die, int value)
        {
            return die.currentValue - value;
        }

        public static int operator -(int value, Die die)
        {
            return value - die.currentValue;
        }


    }
}
