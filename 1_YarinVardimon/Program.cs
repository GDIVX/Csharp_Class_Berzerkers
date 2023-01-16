using _1_YarinVardimon;
using _1_YarinVardimon.Rand;

#region Fighter

//var actorA = Actor.Create(10, 3, Race.Danann, "Eathonimr");
//var actorB = Actor.Create(10, 3, Race.Fomori, "Kalgachye");

//Console.WriteLine("###THE BATTLE BEGINE###");
//Console.WriteLine($"{actorA.name} VS {actorB.name}!");
//Console.WriteLine(actorA.Log());
//Console.WriteLine(actorB.Log());

//Battle battle = new Battle(0.2, 2);
//var results = battle.Fight(actorA.Army, actorB.Army);

//var winner = results.WinningArmy[0].Race == actorA.race ? actorA : actorB;
//var loot = winner.resources < results.Loot ? results.Loot : winner.resources;

//Console.WriteLine($"{winner.name} is the winner!");
//Console.WriteLine($"The army has looted {loot} pounds of loot");
#endregion

#region RandomFighter

//Create a deck of cards from 1 to 20
var deck = new Deck<int>(40);
Random rng = new();

for (int i = 1; i <= 40; i++)
{
    deck.Push(rng.Next(1, 20));
}

deck.Shuffle();

//Create a D20 die
var die = IntegerDice.D20();

//Run the algorithm
RandomFighter<int> randomFighter = new();
randomFighter.Fight(die, deck);


#endregion


public class RandomFighter<T> where T : struct, IComparable<T>
{
    public void Fight(Dice<T> die, Deck<T> deck)
    {
        if (die is null)
        {
            throw new ArgumentNullException(nameof(die));
        }

        if (deck is null)
        {
            throw new ArgumentNullException(nameof(deck));
        }

        T card;
        int diceWins = 0;
        int deckWins = 0;
        int ties = 0;

        while (deck.TryDraw(out card))
        {
            T dieRoll = die.Roll();
            int result = dieRoll.CompareTo(card);

            switch (result)
            {
                case > 0:
                    diceWins++;
                    break;
                case < 0:
                    deckWins++;
                    break;
                default:
                    ties++;
                    break;
            }
        }

        Console.WriteLine($"Dice wins: {diceWins} times" +
            $"\nDeck wins: {deckWins} times" +
            $"\nTies: {ties} times");
    }
}