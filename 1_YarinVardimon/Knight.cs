using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_YarinVardimon
{
    internal class Knight : CavalaryUnit
    {
        int _hp = 16;
        public override int HP { get { return _hp; } protected set { _hp = value; } }
        public override Race Race => Race.Tuatha;

        public Knight()
        {
            _damage = new Bag(new int[] { 0, 1, 3, 5, 5 });
            _defenseRating = new Dice(2, 8, 1);
            _hitChance = new Dice(2, 6, 0);
        }
        public override void Defend(Unit attacker)
        {
            //The knight gain a new charge after taking damage, making him a good tank unit
            base.Defend(attacker);
            CanCharge = true;
        }

        public override string ToString()
        {
            return "Knight";
        }
    }
}
