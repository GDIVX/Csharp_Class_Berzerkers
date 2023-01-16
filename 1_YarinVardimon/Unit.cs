using _1_YarinVardimon.Rand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_YarinVardimon
{
    public abstract class Unit : ICloneable
    {
        virtual public int CarryingCapacity { get; protected set; }
        virtual public int HP { get; protected set; }
        virtual public Race Race { get; private set; }

        protected IRandomProvider _damage { get; set; }
        protected IRandomProvider _hitChance { get; set; }
        protected IRandomProvider _defenseRating { get; set; }

        public Unit() { }

        public int GetDamageRoll() => _damage.GetRandom();
        public int GetDefenseRoll() => _defenseRating.GetRandom();
        public int GetHitRoll() => _hitChance.GetRandom();

        public Weather WeatherEffect { get; set; }
        public bool IsAlive { get { return HP > 0; } }

        public abstract void Attack(Unit target);
        public abstract void Defend(Unit attacker);


        public virtual void TakeDamage(int damage)
        {
            if (!IsAlive) return;
            ModifyHP(-damage);
        }

        public virtual void ModifyHP(int ammount)
        {
            if (!IsAlive)
            {
                Console.WriteLine($"{ToString()} is dead");
                return;
            }
            Console.WriteLine($"{ToString()} have {HP} HP");
            HP += ammount;
        }

        public void ModifyDamage(int ammount)
        {
            if (!IsAlive) return;
            _damage.Extand(ammount);
        }

        public void SetDamage(int value)
        {
            if (!IsAlive) return;
            if (value < 0) return;
            _damage.SetRange(0, value);
        }

        public ICloneable Clone()
        {
            return (Unit)this.MemberwiseClone();
        }

    }

    public enum Race { Tuatha, Danann, Fomori }
    public enum Weather { CLEAR, FOG, RAIN, HAZE }
}
