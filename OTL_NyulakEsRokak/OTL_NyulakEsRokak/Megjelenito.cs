using System;
using System.Diagnostics.Metrics;

namespace OTL_NyulakEsRokak
{
	public class Megjelenito
	{
        public int NumberTestRead()
        {

        }

        public int w = Console.WindowWidth;
        public int h = Console.WindowHeight;

        public Megjelenito()
        {

        }

        public void menuMegjelenites()
        {
            Console.Clear();
            int spacing = (int)(h * 0.2);

            Console.Title = "\tOne of The Lot - Nyulak és Rókák";
            Console.ForegroundColor = ConsoleColor.Green;

            string[] menuItems = { "Játék", "Kilépés" };
            int selectedIndex = 0;

            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.Black;
            while (true)
            {
                Console.Clear();

                for (int i = 0; i < spacing; i++)
                {
                    Console.WriteLine("\n");
                }
                Console.WriteLine("\n\n\n\n\n\n\n\n");

                for (int i = 0; i < menuItems.Length; i++)
                {
                    for (int l = 0; l < (w - menuItems[i].Length) / 2; l++)
                    {
                        Console.Write(" ");
                    }
                    if (i == selectedIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;

                        Console.Write($" {menuItems[i]} \n");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.Write($" {menuItems[i]} \n");
                    }

                    Console.WriteLine("\n");
                }


                string brand = "brand.txt";
                var file = File.ReadAllLines(brand);
                int sorhossz = file[0].ToCharArray().Length;
                int sormagassag = file.Count();
                int counter = 0;

                string brand2 = "brand2.txt";
                var file2 = File.ReadAllLines(brand2);
                int sorhossz2 = file2[0].ToCharArray().Length;
                int sormagassag2 = file2.Count();
                int counter2 = 0;

                string brand3 = "Készült a One of The Lot által";
                int sorhossz3 = brand3.ToCharArray().Count();

                foreach (var sor2 in file2)
                {
                    Console.SetCursorPosition(Convert.ToInt32((w - 0 - sorhossz2) * 0.5), (Convert.ToInt32(sormagassag * 1.4)) + counter2);
                    Console.WriteLine(sor2);
                    counter2++;
                }

                foreach (var sor in file)
                {
                    Console.SetCursorPosition(Convert.ToInt32((w - 0 - sorhossz) * 0.5), 1 + counter);
                    Console.WriteLine(sor);
                    counter++;
                }

                Console.SetCursorPosition(Convert.ToInt32((w - 0 - sorhossz3) * 0.5), Convert.ToInt32(h * 0.95));
                Console.WriteLine(brand3);

                ConsoleKeyInfo keyInfo = Console.ReadKey();

                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    selectedIndex--;

                    if (selectedIndex < 0)
                    {
                        selectedIndex = menuItems.Length - 1;
                    }
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    selectedIndex++;

                    if (selectedIndex >= menuItems.Length)
                    {
                        selectedIndex = 0;
                    }
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    if (menuItems[selectedIndex] == "Játék")
                    {
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

                        if (menuItems[selectedIndex] == "Kilépés")
                        {
                            System.Environment.Exit(0);
                        }


                        Console.ReadKey();
                    }
                }
            }
        }
    }
}

