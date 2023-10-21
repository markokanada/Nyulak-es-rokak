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

            InitializeMap();
        }

        private void InitializeMap()
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                     grassMatrix[i, j] = new Grass(0);
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
                rabbitsList.Add(rabbit);
            }
        }

        public void PlaceFox(int x, int y, int satietyMeter)
        {
            if (x >= 0 && x < width && y >= 0 && y < height)
            {
                Foxes fox = new Foxes(satietyMeter);
                foxesList.Add(fox);
            }
        }
    }
}