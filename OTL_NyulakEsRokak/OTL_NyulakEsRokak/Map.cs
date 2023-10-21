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


        //Map settings
        public Map(int width, int height)
        {
            this.width = width;
            this.height = height;

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


    }
}
