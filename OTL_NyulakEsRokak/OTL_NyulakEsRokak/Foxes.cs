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

		public bool ValidToRecreate(Dictionary<int[], string> surroundings, int[] foxiesPosition)
		{
			bool isThereOtherFox = false;
			bool isThereFreeSpace = false;

			foreach (var item in surroundings)
			{
				if (item.Value == "fox" && (item.Key[0] == foxiesPosition[0] && (item.Key[1] - 1 == foxiesPosition[1] || item.Key[1] + 1 == foxiesPosition[1])))
				{
					isThereOtherFox = true;
				}
				if (item.Value == "" && (item.Key[0] == foxiesPosition[0] && (item.Key[1] - 1 == foxiesPosition[1] || item.Key[1] + 1 == foxiesPosition[1])))
				{
					isThereFreeSpace = true;
				}
			}
			if (isThereOtherFox == true && isThereFreeSpace == true)
			{
				return true;
			}
			else return false;
		}

		//public int[] Moving(Dictionary<int[], string> surroundings, Foxes foxy, int[] foxiesPosition)
		//{
		//	if (surroundings.ContainsValue("rabbit"))
		//	{
		//		return surroundings.First(x => x.Value == "rabbit").Key;
		//	}
		//	else if (surroundings.ContainsValue("fox"))
		//	{
		//		foreach(var item in surroundings)
		//		{
		//			if (item.Value == "fox" && (item.Key[0] == foxiesPosition[0] && (item.Key[1] - 1 == foxiesPosition[1] || item.Key[1] + 1 == foxiesPosition[1])))
		//			{
						
		//				//foxy.recreate();
		//				return foxiesPosition;
		//			}
		//		}
				
		//	}
		//}
	}
}
