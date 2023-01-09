using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_YarinVardimon
{
    internal class Actor
    {
        public List<Unit> Army { get; private set; }
        public int resources { get; set; }
        public Race race { get; private set; }
        public string name { get; private set; }

        private Actor() { }

        public static Actor Create(int armySize, int wealth, Race race, string name)
        {
            Actor actor = new Actor();
            actor.race = race;
            actor.name = name;
            actor.Army = new List<Unit>();
            var rng = new Random();

            actor.resources = rng.Next(15 * wealth, 50 * wealth);

            for (int i = 0; i < armySize; i++)
            {
                actor.Army.Add(GetRandomUnit(race));
            }

            return actor;
        }

        static Dictionary<Race, List<Unit>> UnitsPerRace = new Dictionary<Race, List<Unit>>
        {
            {Race.Danann , new List<Unit>(){
                new Bard(),new Paladin(),new Paladin(),new Bard(),new Paladin(),new Paladin(),new Bard(),new Paladin(),new Paladin()} },
            {Race.Tuatha , new List<Unit>(){
                new Cleric() , new Knight(), new Knight(),new Cleric() , new Knight(), new Knight(),new Cleric() , new Knight(), new Knight()} },
            {Race.Fomori , new List<Unit>(){
                new Druid() , new Marauder(), new Marauder(),new Druid() , new Marauder(), new Marauder(),new Druid() , new Marauder(), new Marauder()}}
        };

        private static Unit GetRandomUnit(Race race)
        {
            var rng = new Random();
            var Units = UnitsPerRace[race];
            return Units[rng.Next(0, Units.Count - 1)];
        }

        public string Log()
        {
            string log = $"{name} Have {resources} and an army of :";
            foreach (var unit in Army)
            {
                log += $" [{unit}] ";
            }
            return log;
        }
    }
}
