namespace GameOfLife;

public static class WorldCreator
{
    public static string Randomize()
    {
        var random = new Random();
        var rowsCount = random.Next(3, 10);
        var colsCount = random.Next(3, 10);

        return string.Join("|",
            Enumerable.Range(0, rowsCount).Select(_ =>
                string.Join(",", Enumerable.Range(0, colsCount).Select(_ => random.Next(2)))
            )
        );
    }
}
