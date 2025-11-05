using GameOfLife;

if (args.Length == 0) throw new ArgumentException("Missing world data");

var world = new World(args[0]);
world.Evolve();

Console.WriteLine(world);
