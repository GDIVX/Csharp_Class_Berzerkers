using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_YarinVardimon
{
    internal class CavalaryUnit : Unit
    {

        protected bool CanCharge { get; set; }

        public override void Attack(Unit target)
        {
            if (!IsAlive || !target.IsAlive) return;

            if (CanCharge)
            {
                Charge(target);
                return;
            }

            var damage = _damage.GetRandom();

            target.TakeDamage(damage);

        }

        public virtual void Charge(Unit target)
        {
            int _attack = _damage.GetRandom();
            _attack -= 2;
            target.TakeDamage(_attack);
            target.Defend(this);
            CanCharge = false;
        }

        public override void ModifyHP(int ammount)
        {
            base.ModifyHP(ammount);
            CanCharge = true;
        }

        public override void Defend(Unit attacker)
        {
            var _damage = attacker.GetDamageRoll();
            if (CanCharge)
            {
                CanCharge = false;
                _damage = (int)MathF.Floor(_damage / 2);
            }
            TakeDamage(_damage);
        }

    }
}
