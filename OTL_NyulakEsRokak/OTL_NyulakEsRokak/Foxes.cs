﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTL_NyulakEsRokak
{
	internal class Foxes
	{
		public int SatietyMeter;
		public static int MaximumStepDistance = 2;

		public Foxes(int satietyMeter)
		{
			SatietyMeter = satietyMeter;
		}
		
		public int EatingRabbit(int nutritionalValue)
		{
			if (nutritionalValue < 10 && nutritionalValue + SatietyMeter <= 10) 
			{
				SatietyMeter += nutritionalValue;
				return SatietyMeter;
			}
			return SatietyMeter;
		}

		public int DidntHadFood()
		{
			SatietyMeter -= 1;
			if (SatietyMeter <= 0)
			{
				return -1;
			}
			else
			{
				return 0;
			}
		}
	}
}