using System;
namespace OTL_NyulakEsRokak
{
	public class Megjelenito
	{
        public int w = Console.WindowWidth;
        public int h = Console.WindowHeight;

        public Megjelenito()
        {

        }

        public void menuMegjelenites()
        {
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.Black;

            Console.Clear();
            Console.Title = "\tOne of The Lot - Nyulak és Rókák";

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

        }
    }
}

