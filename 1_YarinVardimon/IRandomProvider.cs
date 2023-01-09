using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_YarinVardimon
{
    public interface IRandomProvider
    {
        public int GetRandom();
        public void Extand(int value);
        public void SetRange(int min, int max);
    }
}
