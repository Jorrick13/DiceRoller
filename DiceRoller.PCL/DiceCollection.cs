using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRoller.PCL
{
    public class DiceCollection
    {
        #region Properties

        /// <summary>
        /// The collection of dice.
        /// </summary>
        public IList<Die> Dice { get; set; }
        /// <summary>
        /// The modifier to the roll sum. 
        /// </summary>
        public int Modifier { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Takes a list of dice and an optional modifier to create a dice colection
        /// </summary>
        /// <param name="dice">The list of dice in the collection</param>
        /// <param name="modifier">The modifier for the final sum of all dice in collection. Added once per roll to the collection</param>
        public DiceCollection(IList<Die> dice, int modifier = 0)
        {
            Dice = dice;
            Modifier = modifier;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Rolls all dice in the collection
        /// </summary>
        public void Roll()
        {
            foreach (var die in Dice)
            {
                die.Roll();
            }

        }

        /// <summary>
        /// Returns a list of the specified size sorted by highest die value. Defaults to returning the highest single die
        /// </summary>
        /// <param name="NumberOfDice">Number of dice to return. Defaults to 1. Must be larger than zero and less than or equal to the size of the collection</param>
        /// <returns></returns>
        public List<int> GetHighest(int NumberOfDice = 1)
        {
            if (NumberOfDice > Dice.Count || NumberOfDice < 1)
            {
                throw new ArgumentOutOfRangeException("Please specify a valid number of dice.");
            }

            return Dice.OrderByDescending(d => d.currentValue).Take(NumberOfDice).Select(d => d.currentValue).ToList();
        }

        /// <summary>
        /// Returns the sum of the highest x amount of dice as an int. Defaults to the single highest die
        /// </summary>
        /// <param name="NumberOfDice">Optional: specifies the number of dice to sum. Defaults to 1. Must be at least 1 and less than or equal to the amount of dice in the collection</param>
        /// <returns></returns>
        public int SumHighest(int NumberOfDice = 1)
        {
            if (NumberOfDice > Dice.Count || NumberOfDice < 1)
            {
                throw new ArgumentOutOfRangeException("Please specify a valid number of dice.");
            }

            return Dice.OrderByDescending(d => d.currentValue).Take(NumberOfDice).Sum(d => d.currentValue);
        }

        /// <summary>
        /// Returns the current value of all dice in the collection including the modifier as an int
        /// </summary>
        /// <returns></returns>
        public int Sum()
        {
            return Dice.Sum(d => d.currentValue) + Modifier;
        }

#endregion Methods

        //Suck it Java
        #region Operator Overloads 

        /// <summary>
        /// Sums the total value of 2 dice collections and returns the value as an int. 
        /// </summary>
        /// <param name="diceCollection1">First dice collection</param>
        /// <param name="diceCollection2">Second dice collection</param>
        /// <returns></returns>
        public static int operator +(DiceCollection diceCollection1, DiceCollection diceCollection2)
        {
            return diceCollection1.Sum() + diceCollection2.Sum(); 
        }

        /// <summary>
        /// Sums the value of a dice collection with the value of a single die. Returns value as an int
        /// </summary>
        /// <param name="diceCollection">The dice collection</param>
        /// <param name="die">The die to add</param>
        /// <returns></returns>
        public static int operator +(DiceCollection diceCollection, Die die)
        {
            return diceCollection.Sum() + die.currentValue;
        }

        /// <summary>
        /// Sums the value of a single die with the value of a dice collection
        /// </summary>
        /// <param name="die">Die to add</param>
        /// <param name="diceCollection">Dice collection to add</param>
        /// <returns></returns>
        public static int operator +(Die die, DiceCollection diceCollection)
        {
            return diceCollection + die;
        }

        /// <summary>
        /// Adds an int to the value of a dice collection. Returns total as int
        /// </summary>
        /// <param name="diceCollection">Dice collection to add value to</param>
        /// <param name="value">Int to add</param>
        /// <returns></returns>
        public static int operator +(DiceCollection diceCollection, int value)
        {
            return diceCollection.Sum() + value;
        }

        /// <summary>
        /// Adds the value of a dice collection to an int value
        /// </summary>
        /// <param name="value">Int value</param>
        /// <param name="diceCollection">Dice collection to add</param>
        /// <returns></returns>
        public static int operator +(int value, DiceCollection diceCollection)
        {
            return diceCollection + value;
        }

        /// <summary>
        /// Subtracts the value of one dice collection from another. Returns total as an int
        /// </summary>
        /// <param name="diceCollection1">First dice collection</param>
        /// <param name="diceCollection2">Second dice collection</param>
        /// <returns></returns>
        public static int operator -(DiceCollection diceCollection1, DiceCollection diceCollection2)
        {
            return diceCollection1.Sum() - diceCollection2.Sum();
        }

        /// <summary>
        /// Subtracts the value of a die from the value of a dice collection
        /// </summary>
        /// <param name="diceCollection">The dice collection</param>
        /// <param name="die">The int to subtract</param>
        /// <returns></returns>
        public static int operator -(DiceCollection diceCollection, Die die)
        {
            return diceCollection.Sum() - die.currentValue;
        }

        /// <summary>
        /// Subtracts the value of a dice collection from the value of a die
        /// </summary>
        /// <param name="die">The die</param>
        /// <param name="diceCollection">The dice collection</param>
        /// <returns></returns>
        public static int operator -(Die die, DiceCollection diceCollection)
        {
            return die.currentValue - diceCollection.Sum();
        }

        /// <summary>
        /// Subtracts an int from the value of a dice collection
        /// </summary>
        /// <param name="diceCollection">The dice collection</param>
        /// <param name="value">The value to subtract</param>
        /// <returns></returns>
        public static int operator -(DiceCollection diceCollection, int value)
        {
            return diceCollection.Sum() - value;
        }

        /// <summary>
        /// Subtracts the value of a dice collection from the value of an int
        /// </summary>
        /// <param name="value">The value</param>
        /// <param name="diceCollection">The dice collection</param>
        /// <returns></returns>
        public static int operator -(int value, DiceCollection diceCollection)
        {
            return value - diceCollection.Sum();
        }

#endregion Operator Overloads

    }
}
