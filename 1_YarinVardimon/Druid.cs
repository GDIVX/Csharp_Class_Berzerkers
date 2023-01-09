using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_YarinVardimon
{
    internal class Druid : Healer
    {
        int _hp = 7;
        public override int HP { get { return _hp; } protected set { _hp = value; } }
        public override Race Race => Race.Fomori;

        public Druid()
        {
            _damage = new Bag(new int[] { 0, 1, 3, 5, 5 });
            _defenseRating = new Dice(2, 6, 1);
            _hitChance = new Dice(1, 12, 0);
        }

        void Curse(Unit target)
        {
            target.Defend(this);
            target.ModifyDamage(1);
        }

        public override void Attack(Unit target)
        {
            if (target.Race == Race.Fomori)
            {
                base.Attack(target);
            }
            else
            {
                Curse(target);
            }
        }

        public override string ToString()
        {
            return "Druid";
        }
    }
}
