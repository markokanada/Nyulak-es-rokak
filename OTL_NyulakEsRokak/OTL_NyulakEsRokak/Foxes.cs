using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTL_NyulakEsRokak
{
	internal class Foxes
	{
		public int SatietyMeter;
		public static int MaximumStapDistance = 2;

		public Foxes(int satietyMeter)
		{
			SatietyMeter = satietyMeter;
		}
		
		public void EatingRabbit()
		{
			SatietyMeter -= 1;
		}
	}
}
