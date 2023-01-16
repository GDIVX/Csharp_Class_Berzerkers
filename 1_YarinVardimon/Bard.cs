using _1_YarinVardimon.Rand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_YarinVardimon
{
    internal class Bard : Healer
    {
        int _hp = 6;

        public Bard()
        {
            _damage = new Bag(new int[] { 1, 2, 3, 4, 5 });
            _defenseRating = IntegerDice.D6(2, 1);
            _hitChance = IntegerDice.D12();
        }

        public override int HP { get { return _hp; } protected set { _hp = value; } }
        public override Race Race => Race.Danann;

        public override void Attack(Unit target)
        {
            base.Attack(target);
            target.ModifyDamage(1);
        }

        public override string ToString()
        {
            return "Bard";
        }

    }
}
