namespace _1_YarinVardimon.Rand
{
    public class Dice<T> where T : IComparable<T>
    {
        private Random _random;
        public T[] Sides { get; protected set; }

        public Dice(T[] sides)
        {
            _random = new Random();
            Sides = sides;
        }

        public T Roll()
        {
            int index = _random.Next(0, Sides.Length);
            return Sides[index];
        }
    }
}
