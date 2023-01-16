using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_YarinVardimon.Rand
{
    internal class Deck<T> where T : struct, IComparable<T>
    {
        Stack<T> _content;
        Stack<T> _discards;

        public int Remaining => _content.Count;

        public int CountDiscard => _discards.Count;

        public int Size { get; private set; }

        public Deck(int size)
        {
            for (int i = 0; i < size; i++)
            {
                _content?.Push(new T());

            }
            _discards = new Stack<T>();
            Size = size;
            Shuffle();
        }


        /// <summary>
        /// Shuffle the deck
        /// </summary>
        public void Shuffle()
        {
            var rnd = new Random();
            var array = _content.ToArray();
            for (int i = 0; i < _content.Count - 1; i++)
            {
                var pick = rnd.Next(0, i);

                var tempt = array[i];
                array[i] = array[pick];
                array[pick] = tempt;
            }

            _content = new Stack<T>(array);
        }

        /// <summary>
        /// Conjoin the discard pile with the draw pile, and then shuffle them
        /// </summary>
        public void Reshuffle()
        {
            var conjoined = _content.Concat(_discards).ToArray();
            _content = new Stack<T>(conjoined);
            Shuffle();
        }

        public bool TryDraw(out T card)
        {
            if (_content.Count == 0)
            {
                card = default;
                return false;
            }

            card = _content.Pop();
            return true;
        }

        public T Peek()
        {
            return _content.Peek();
        }


    }
}
