using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_YarinVardimon
{
    internal class Paladin : CavalaryUnit
    {
        int _hp = 12;
        public override int HP { get { return _hp; } protected set { _hp = value; } }
        public override Race Race => Race.Danann;

        public Paladin()
        {
            _damage = new Bag(new int[] { 2, 2, 4, 4, 4 });
            _defenseRating = new Dice(4, 4, 2);
            _hitChance = new Dice(2, 6, 0);
        }

        public override void Charge(Unit target)
        {
            int _attack = _damage.GetRandom();
            _attack -= 1;
            target.TakeDamage(_attack);
            target.Defend(this);
            CanCharge = false;
        }

        public override string ToString()
        {
            return "Paladin";
        }
    }
}
