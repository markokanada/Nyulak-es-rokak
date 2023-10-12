using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTL_NyulakEsRokak
{
	internal class Rabbits
	{
		private int SatietyMeter;
		public static int NutritionScore = 3;
		public static int MaximumStepDistance = 1;

		public Rabbits(int satietyMeter)
		{
			SatietyMeter = satietyMeter;
		}

		public int EatingGrass(int nutritionalValue)
		{
			if (nutritionalValue + SatietyMeter < 5 && SatietyMeter < 5)
			{
				SatietyMeter += nutritionalValue;
				return SatietyMeter;
			}
			return SatietyMeter;
		}

		public int DidntHadFood(int hungerness = 1)
		{
			SatietyMeter -= hungerness;
			if (SatietyMeter <= 0)
			{
				return -1;
			}
			return 0;
		}

		public int GotEaten(Foxes fox)
		{
			SatietyMeter = 0;
			fox.EatingRabbit(2);
			return SatietyMeter;
		}
	}
}
