﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTL_NyulakEsRokak
{
	internal class Rabbits
	{
		private int SatietyMeter;
		public static int MaximumStepDistance = 1;

		public Rabbits(int satietyMeter)
		{
			SatietyMeter = satietyMeter;
		}

		public int DidntHadFood()
		{
			SatietyMeter -= 1;
			if (SatietyMeter <= 0)
			{
				return -1;
			}
			return 0;
		}
	}
}
