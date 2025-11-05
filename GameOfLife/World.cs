namespace GameOfLife;

public class World
{
    private bool[][] _world;

    public World(string world)
    {
        _world = world.Split('|').Select(row => row.Split(',').Select(cell => cell == "1").ToArray()).ToArray();
    }

    public void Evolve()
    {
        // 1. Any live cell with fewer than two live neighbours dies, as if caused by underpopulation.
        // 2. Any live cell with more than three live neighbours dies, as if by overcrowding.
        // 3. Any live cell with two or three live neighbours lives on to the next generation.
        // 4. Any dead cell with exactly three live neighbours becomes a live cell.

        var buffer = new bool[_world.Length][];
        for (var y = 0; y < _world.Length; y++)
        {
            buffer[y] = new bool[_world[y].Length];

            for (var x = 0; x < _world[y].Length; x++)
            {
                EvolveCell(x, y, buffer);
            }
        }

        _world = buffer;
    }

    public override string ToString()
    {
        return string.Join("\n", _world.Select(row => string.Join(",", row.Select(cell => cell ? "1" : "0"))));
    }

    private void EvolveCell(int x, int y, bool[][] buffer)
    {
        var neighborhoodValue = GetNeighborhoodValue(x, y);
        buffer[y][x] = _world[y][x] switch
        {
            false => neighborhoodValue == 3,
            true => neighborhoodValue is 2 or 3
        };
    }

    private int GetNeighborhoodValue(int x, int y)
    {
        var value = 0;
        foreach (var dy in Enumerable.Range(y - 1, 3))
        {
            if (dy < 0 || dy >= _world.Length) continue;

            foreach (var dx in Enumerable.Range(x - 1, 3))
            {
                if (dx < 0 || dx >= _world[dy].Length) continue;
                if (dx == x && dy == y) continue;

                value += _world[dy][dx] ? 1 : 0;
            }
        }

        return value;
    }
}
