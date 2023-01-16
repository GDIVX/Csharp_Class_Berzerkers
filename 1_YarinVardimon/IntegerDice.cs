using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_YarinVardimon.Rand
{
    public class IntegerDice : Dice<int>, IRandomProvider
    {

        public uint Scalar { get; set; }
        public uint BaseDie => (uint)Sides.Length;
        public int Modifier { get; set; }

        public IntegerDice(int[] sides, uint scalar, int modifier) : base(sides)
        {
            Sides = sides;
            Scalar = scalar;
            Modifier = modifier;
        }

        #region Factory methods

        //Methods for common type of dices

        public static IntegerDice Coin(uint scalar = 1, int modifier = 0)
        {
            return new(new int[] { 0, 1 }, scalar, modifier);
        }

        public static IntegerDice D4(uint scalar = 1, int modifier = 0)
        {
            return new(new int[] { 1, 2, 3, 4 }, scalar, modifier);
        }

        public static IntegerDice D6(uint scalar = 1, int modifier = 0)
        {
            return new(new int[] { 1, 2, 3, 4, 5, 6 }, scalar, modifier);
        }

        public static IntegerDice D8(uint scalar = 1, int modifier = 0)
        {
            return new(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, scalar, modifier);
        }

        public static IntegerDice D10(uint scalar = 1, int modifier = 0)
        {
            return new(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, scalar, modifier);
        }

        public static IntegerDice D12(uint scalar = 1, int modifier = 0)
        {
            return new IntegerDice(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, scalar, modifier);
        }

        public static IntegerDice D20(uint scalar = 1, int modifier = 0)
        {
            return new IntegerDice(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 }, scalar, modifier);
        }

        #endregion

        /// <summary>
        /// Roll the dice Scalar times and return the sum of the results
        /// </summary>
        /// <returns>Random integer</returns>
        int IRandomProvider.GetRandom()
        {
            int sum = 0;
            for (int i = 0; i < Scalar; i++)
            {
                sum += Roll();
            }
            return sum + Modifier;
        }

        public override string ToString()
        {
            string sign = Modifier > 0 ? "+" : Modifier < 0 ? "-" : "";
            string mod = Modifier != 0 ? $"{sign}{Modifier}" : "";
            return $"{Scalar}d{BaseDie}{mod}";
        }

        public void Extand(int value)
        {
            Modifier += value;
        }

        public void SetRange(int min, int max)
        {
            Sides = Enumerable.Range(min, max - min + 1).ToArray();
        }
    }
}
