using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OTL_NyulakEsRokak
{
    internal class Map
    {
        private readonly int width;
        private readonly int height;
        private readonly Random random = new Random();
        private readonly Grass[,] grassMatrix;
        public readonly Entyti[,] entytis;
        private readonly List<Rabbits> rabbitsList = new List<Rabbits>();
        private readonly List<Foxes> foxesList = new List<Foxes>();
        public int GetWidth()
        {
            return width;
        }

        public int GetHeight()
        {
            return height;
        }

        public Map(int width, int height)
        {
            this.width = width;
            this.height = height;
            grassMatrix = new Grass[width, height];
            entytis = new Entyti[width, height];

            InitializeMap();
        }

        private void InitializeMap()
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                     grassMatrix[i, j] = new Grass(0);
                    entytis[i, j] = new Grass(0);
                }
            }
        }



        public void PlaceGrass(int x, int y, int nutritionalValue)
        {
            if (x >= 0 && x < width && y >= 0 && y < height)
            {
                grassMatrix[x, y] = new Grass(nutritionalValue);
               
            }
        }

        public void PlaceRabbit(int x, int y, int satietyMeter)
        {
            if (x >= 0 && x < width && y >= 0 && y < height)
            {
                Rabbits rabbit = new Rabbits(satietyMeter);
                entytis[x,y] = rabbit;
                rabbitsList.Add(rabbit);
            }
        }

        public void PlaceFox(int x, int y, int satietyMeter)
        {
            if (x >= 0 && x < width && y >= 0 && y < height)
            {
                Foxes fox = new Foxes(satietyMeter);
                entytis[x,y] = fox;
                foxesList.Add(fox);
            }
        }



        public void SimulateRound(Map map)
        {
            //GrowGrass();
            Console.WriteLine(foxesList.Count);
            Console.WriteLine(rabbitsList.Count);
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    entytis[i, j].SimulatingRound(map);
                }
            }
        }


        public string GetGrassType(int x, int y)
        {
            if (x >= 0 && x < width && y >= 0 && y < height)
            {
                return grassMatrix[x, y].GetTheTypeOfGrass();
            }
            else
            {
                return "Invalid Coordinates";
            }
        }


        private void GrowGrass()
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {

                    if (grassMatrix[i, j].NutritionalValue < 2)
                    {
                        grassMatrix[i, j] = new Grass(grassMatrix[i, j].NutritionalValue + 1);
                    }
                }
            }
        }
    }
}