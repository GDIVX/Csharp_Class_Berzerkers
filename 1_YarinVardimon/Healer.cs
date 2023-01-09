using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_YarinVardimon
{
    internal class Healer : Unit
    {

        public override void Attack(Unit target)
        {
            if (!IsAlive || !target.IsAlive) return;
            var _attackValue = _damage.GetRandom();
            target.ModifyHP(_attackValue);
        }

        public override void Defend(Unit attacker)
        {
            var hit = attacker.GetHitRoll();
            var defense = GetDefenseRoll();
            if (hit > defense)
            {
                var attack = attacker.GetDamageRoll();
                TakeDamage(attack);
            }
        }

    }
}
