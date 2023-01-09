using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_YarinVardimon
{
    internal class Cleric : Healer
    {
        int _hp = 8;
        public override int HP { get { return _hp; } protected set { _hp = value; } }
        public override Race Race => Race.Tuatha;
        
        public Cleric()
        {
            _damage = new Bag(new int[] { 1, 1, 1, 2, 3 });
            _defenseRating = new Dice(2, 6, 1);
            _hitChance = new Dice(1, 12, 0);
        }

        // The cleric become a more effective healer the more it heals, but loose all progress when hit.
       
        public override void Attack(Unit target)
        {
            base.Attack(target);
            ModifyDamage(2);
        }

        public override void Defend(Unit attacker)
        {
            base.Defend(attacker);
            SetDamage(3);
        }

        public override string ToString()
        {
            return "Cleric";
        }
    }
}
