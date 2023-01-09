using _1_YarinVardimon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_YarinVardimon
{
    internal class Battle
    {
        double weatherEffectChance;
        int weatherDuration;
        int currentWeatherRunningTime = 0;
        Weather Weather;

        public Battle(double weatherEffectChance, int weatherDuration)
        {
            this.weatherEffectChance = weatherEffectChance;
            this.weatherDuration = weatherDuration;
            Weather = Weather.CLEAR;
        }

        public BattleResults Fight(List<Unit> armyA, List<Unit> armyB)
        {
            var rand = new Random();

            while (armyA.Count > 0 && armyB.Count > 0)
            {
                //Handle Weather
                HandleWatherChange();
                ChangeWeather(armyA);
                ChangeWeather(armyB);

                //Pick random attackers
                Unit unitA = armyA[rand.Next(0, armyA.Count - 1)];
                Unit unitB = armyB[rand.Next(0, armyB.Count - 1)];

                Console.WriteLine($"{unitA} VS {unitB}");

                //Attack
                Console.WriteLine($"{unitA} VS {unitB}");
                unitA.Attack(unitB);
                unitB.Attack(unitA);


                //Remove dead units
                armyA = RemoveIfDead(unitA, armyA);
                armyB = RemoveIfDead(unitB, armyB);
            }

            //Declare the winner
            var winnigArmy = armyA.Count > 0 ? armyA : armyB;
            var loot = CalculateLoot(winnigArmy);
            return new BattleResults(winnigArmy, loot);

        }

        public int CalculateLoot(List<Unit> army)
        {
            var loot = 0;
            foreach (var unit in army)
            {
                loot += unit.CarryingCapacity;
            }
            return loot;
        }

        void HandleWatherChange()
        {
            var rng = new Random();
            if (Weather == Weather.CLEAR)
            {
                //No active weather effect
                //Roll for starting weather
                Weather = rng.Next(0, 1) >= weatherEffectChance ?
                    Weather.CLEAR : (Weather)rng.Next(1, 3);
                currentWeatherRunningTime = 0;
                Console.WriteLine($"It is now {Weather}");
            }
            else if (currentWeatherRunningTime >= weatherDuration)
            {
                Console.WriteLine($"The {Weather} has cleared");
                Weather = Weather.CLEAR;
            }
            else
            {
                currentWeatherRunningTime++;
            }
        }

        List<Unit> ChangeWeather(List<Unit> army)
        {
            if (Weather == Weather.CLEAR) return army;

            foreach (Unit unit in army)
            {
                unit.WeatherEffect = Weather;
            }
            return army;

        }

        List<Unit> RemoveIfDead(Unit unit, List<Unit> army)
        {
            if (army.Contains(unit) && !unit.IsAlive)
            {
                army.Remove(unit);
            }
            return army;

        }

    }

}

public class BattleResults
{
    public BattleResults(List<Unit> winningArmy, int loot)
    {
        WinningArmy = winningArmy;
        Loot = loot;
    }

    public List<Unit> WinningArmy { get; private set; }
    public int Loot { get; private set; }
}
