using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_YarinVardimon
{
    internal class Marauder : CavalaryUnit
    {
        int _hp = 10;
        public override int HP { get { return _hp; } protected set { _hp = value; } }
        public override Race Race => Race.Fomori;

        //Kamakazi unit that explode when killed

        public Marauder()
        {
            _damage = new Bag(new int[] { 0, 0, 2, 6, 6 });
            _defenseRating = new Dice(2, 4, 2);
            _hitChance = new Dice(3, 4, 0);
        }
        public override void Defend(Unit attacker)
        {
            base.Defend(attacker);
            if (!IsAlive)
            {
                SetDamage(4);
                Attack(attacker);
            }
        }

        public override string ToString()
        {
            return "Marauder";
        }
    }
}
