using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTL_NyulakEsRokak
{
	internal class Foxes : Entyti
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

		public int[] GetFreeSpace(Dictionary<int[], string> surroundings, int[] foxiesPosition)
		{
			if (surroundings.Count > 0)
			{
				foreach (var item in surroundings)
				{
					if (item.Key[0] == foxiesPosition[0] && item.Value == "")
					{
						if (item.Key[1] - 1 == foxiesPosition[1])
						{
							return item.Key;
						}
						else if (item.Key[1] + 1 == foxiesPosition[1])
						{
							return item.Key;
						}
						else if (item.Key[1] - 2 == foxiesPosition[1])
						{
							return item.Key;
						}
						else if (item.Key[1] + 2 == foxiesPosition[1])
						{
							return item.Key;
						}
						return foxiesPosition;
					}
					else if (item.Key[1] == foxiesPosition[1] && item.Value == "")
					{
						if (item.Key[0] - 1 == foxiesPosition[0])
						{
							return item.Key;
						}
						else if (item.Key[0] + 1 == foxiesPosition[0])
						{
							return item.Key;
						}
						else if (item.Key[0] - 2 == foxiesPosition[0])
						{
							return item.Key;
						}
						else if (item.Key[0] + 2 == foxiesPosition[0])
						{
							return item.Key;
						}
						return foxiesPosition;
					}
					else if (item.Value == "" && item.Key[0] + 1 == foxiesPosition[0])
					{
						if (item.Key[1] + 1 == foxiesPosition[1])
						{
							return item.Key;
						}
						else if (item.Key[1] - 1 == foxiesPosition[1])
						{
							return item.Key;
						}
						return foxiesPosition;
					}
					else if (item.Value == "" && item.Key[0] - 1 == foxiesPosition[0])
					{
						if (item.Key[1] + 1 == foxiesPosition[1])
						{
							return item.Key;
						}
						else if (item.Key[1] - 1 == foxiesPosition[1])
						{
							return item.Key;
						}
						return foxiesPosition;
					}
					return foxiesPosition;
				}
			}
			return foxiesPosition;
		}

		public int[] Recreate(Dictionary<int[], string> surroundings, int[] foxiesPosition)
		{
			foreach (var item in surroundings)
			{
				if (item.Key[0] == foxiesPosition[0] && item.Value == "")
				{
					if (item.Key[1] + 1 == foxiesPosition[1])
					{
						return item.Key;
					}
					else if (item.Key[1] - 1 == foxiesPosition[1])
					{
						return item.Key;
					}
				}
				else if (item.Key[1] == foxiesPosition[1] && item.Value == "")
				{
					if (item.Key[0] + 1 == foxiesPosition[0])
					{
						return item.Key;
					}
					else if (item.Key[0] - 1 == foxiesPosition[0])
					{
						return item.Key;
					}
				}
			}
			return new int[] { -100, -100 };
		}

		public int[] Moving(Dictionary<int[], string> surroundings, Foxes foxy, int[] foxiesPosition)
		{
			if (surroundings.ContainsValue("rabbit"))
			{
				return surroundings.First(x => x.Value == "rabbit").Key;
			}
			else if (ValidToRecreate(surroundings, foxiesPosition))
			{
				return foxy.Recreate(surroundings, foxiesPosition);
			}
			else
			{
				return GetFreeSpace(surroundings, foxiesPosition);
			}
		}

		public override string ToString()
		{
			return "róka";
		}

		
	}
}
