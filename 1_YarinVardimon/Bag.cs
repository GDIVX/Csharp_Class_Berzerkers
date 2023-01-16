using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_YarinVardimon.Rand
{
    public class Bag : IRandomProvider
    {
        Stack<int> _content;
        List<int> _discards;
        public int Count => _content.Count;
        public int CountDiscard => _discards.Count;



        public Bag(int[] content)
        {
            _content = new(content);
            _discards = new();
            Shuffle();
        }
        public void Extand(int value)
        {
            _content.Push(value);
            Shuffle();
        }

        private void Shuffle()
        {
            Random rnd = new Random();
            var array = _content.ToArray();
            for (int i = 0; i < _content.Count - 1; i++)
            {
                var pick = rnd.Next(0, i);

                var tempt = array[i];
                array[i] = array[pick];
                array[pick] = tempt;
            }

            _content = new(array);
        }

        public int GetRandom()
        {
            if (_content.Count == 0)
            {
                Reset();
            }

            var res = _content.Pop();
            _discards.Add(res);
            return res;
        }


        void Reset()
        {
            _content = new(_discards);
            _discards.Clear();
            Shuffle();

        }

        public void SetRange(int min, int max)
        {
            if (!_content.Contains(min))
            {
                Extand(min);
            }
            if (!_content.Contains(max))
            {
                Extand(max);
            }
            Shuffle();
        }
    }
}
