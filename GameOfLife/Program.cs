namespace GameOfLife;

internal static class Program
{
    public static void Main(string[] args)
    {
        var world = new World(args.Length == 0 ? WorldCreator.Randomize() : args[0]);
        PrintWorld("Initial world", world);

        world.Evolve();
        PrintWorld("Evolved world", world);
    }

    private static void PrintWorld(string title, World world)
    {
        Console.WriteLine(title);
        Console.WriteLine(world);
        Console.WriteLine();
    }
}
