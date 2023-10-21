using OTL_NyulakEsRokak;

Console.Write("Mekkor legyen a térkép?");
int mapSize = int.Parse(Console.ReadLine());
Console.Write("Hány kört szeretnél játszani?");
int roundNumber = int.Parse(Console.ReadLine());

Map gameMap = new Map(mapSize, mapSize);

gameMap.PlaceGrass(1, 1, 2);
gameMap.PlaceRabbit(2, 2, 3);
gameMap.PlaceFox(3, 3, 5);


int round = 1;

while (roundNumber > 0)
{
    gameMap.SimulateRound();

    Console.WriteLine($"Kör {round} állapota:");
    PrintMap(gameMap);

    Console.WriteLine("Nyomj Enter-t a következő körhöz...");
    Console.ReadLine();
    roundNumber--;
    Console.Clear();

    round++;
}


static void PrintMap(Map map)
{
    int width = map.GetWidth();
    int height = map.GetHeight();

    for (int i = 0; i < width; i++)
    {
        for (int j = 0; j < height; j++)
        {
            Console.Write(map.GetGrassType(i, j) + "\t");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}