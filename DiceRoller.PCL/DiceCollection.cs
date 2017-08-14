using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRoller.PCL
{
    public class DiceCollection
    {

        public IList<Die> Dice { get; set; }
        public int Modifier { get; set; }

        public DiceCollection(IList<Die> dice, int modifier = 0)
        {
            Dice = dice;
            Modifier = modifier;
        }


        public void Roll()
        {
            foreach (var die in Dice)
            {
                die.Roll();
            }

        }

        public int Sum()
        {
            return Dice.Sum(d => d.currentValue) + Modifier;
        }

        public static int operator +(DiceCollection diceCollection1, DiceCollection diceCollection2)
        {
            return diceCollection1.Sum() + diceCollection2.Sum(); 
        }

        public static int operator +(DiceCollection diceCollection, Die die)
        {
            return diceCollection.Sum() + die.currentValue;
        }

        public static int operator +(Die die, DiceCollection diceCollection)
        {
            return diceCollection + die;
        }

        public static int operator +(DiceCollection diceCollection, int value)
        {
            return diceCollection.Sum() + value;
        }

        public static int operator +(int value, DiceCollection diceCollection)
        {
            return diceCollection + value;
        }

        public static int operator -(DiceCollection diceCollection1, DiceCollection diceCollection2)
        {
            return diceCollection1.Sum() - diceCollection2.Sum();
        }

        public static int operator -(DiceCollection diceCollection, Die die)
        {
            return diceCollection.Sum() - die.currentValue;
        }

        public static int operator -(Die die, DiceCollection diceCollection)
        {
            return die.currentValue - diceCollection.Sum();
        }

        public static int operator -(DiceCollection diceCollection, int value)
        {
            return diceCollection.Sum() - value;
        }

        public static int operator -(int value, DiceCollection diceCollection)
        {
            return value - diceCollection.Sum();
        }


    }
}
