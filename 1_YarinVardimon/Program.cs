using _1_YarinVardimon;

var actorA = Actor.Create(10, 3, Race.Danann, "Eathonimr");
var actorB = Actor.Create(10, 3, Race.Fomori, "Kalgachye");

Console.WriteLine("###THE BATTLE BEGINE###");
Console.WriteLine($"{actorA.name} VS {actorB.name}!");
Console.WriteLine(actorA.Log());
Console.WriteLine(actorB.Log());

Battle battle = new Battle(0.2, 2);
var results = battle.Fight(actorA.Army, actorB.Army);

var winner = results.WinningArmy[0].Race == actorA.race ? actorA : actorB;
var loot = winner.resources < results.Loot ? results.Loot : winner.resources;

Console.WriteLine($"{winner.name} is the winner!");
Console.WriteLine($"The army has looted {loot} pounds of loot");

