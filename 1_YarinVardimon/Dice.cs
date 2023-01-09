using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_YarinVardimon
{
    public struct Dice : IRandomProvider
    {

        public uint scalar { get; set; }
        public uint baseDie { get; private set; }
        public int modifier { get; set; }

        public Dice(uint scalar, uint baseDie, int modifier)
        {
            this.scalar = scalar;
            this.baseDie = baseDie;
            this.modifier = modifier;
        }

        private int Roll()
        {
            if (scalar == 0) return 0;
            int sum = 0;
            var rng = new Random();
            for (int i = 0; i < scalar; i++)
            {
                sum += rng.Next(1, (int)baseDie);
            }
            return sum;
        }



        public Dice Clone()
        {
            return new Dice(scalar, baseDie, modifier);
        }


        public override bool Equals(object? obj)
        {
            return obj is Dice dice &&
                   scalar == dice.scalar &&
                   baseDie == dice.baseDie &&
                   modifier == dice.modifier;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(scalar, baseDie, modifier);
        }

        public override string? ToString()
        {
            return $"{scalar}d{baseDie}{(modifier > 0 ? $"+{modifier}" : (modifier < 0 ? modifier : ' '))}";
        }

        public int GetRandom()
        {
            return Roll();
        }

        public void Extand(int value)
        {
            modifier += value;

        }

        public void SetRange(int min, int max)
        {
            scalar = (uint)min;
            modifier = max;
        }
    }
}
