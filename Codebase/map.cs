public class Map
{
    private int[,] grid;
    private int width;
    private int height;

    public Map(int width, int height)
    {
        this.width = width;
        this.height = height;
        grid = new int[width, height];
    }

    public void SetTile(int x, int y, int tileType)
    {
        if (IsValidPosition(x, y))
        {
            grid[x, y] = tileType;
        }
    }

    public int GetTile(int x, int y)
    {
        if (IsValidPosition(x, y))
        {
            return grid[x, y];
        }
        return -1; // Return -1 for invalid positions
    }

    private bool IsValidPosition(int x, int y)
    {
        return x >= 0 && x < width && y >= 0 && y < height;
    }

    public void PrintMap()
    {
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                Console.Write(grid[x, y] + " ");
            }
            Console.WriteLine();
        }
    }

    // Additional methods can be added here, such as:
    // - FindPath(int startX, int startY, int endX, int endY)
    // - GenerateRandomMap()
    // - SaveMap(string filename)
    // - LoadMap(string filename)
}

