using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTL_NyulakEsRokak
{
	internal class Grass : Entyti
	{
		public Grass(int nutritionalValue)
		{
			NutritionalValue = nutritionalValue;
		}

		public int NutritionalValue { get; set; }

		public string GetTheTypeOfGrass()
		{
			if (this.NutritionalValue == 0) 
			{
				return "Fű kezdemény";
			}
			else if (this.NutritionalValue == 1)
			{
				return "Zsenge Fű";
			}
			else if (this.NutritionalValue == 2)
			{
				return "Fű csomó";
			}
			return "";

		}

		public override Map SimulatingRound(Map map)
		{
			if (NutritionalValue < 2)
			{
				NutritionalValue += 1;
			}
			return map;
		}

		public override string ToString()
		{
			return this.GetTheTypeOfGrass();
		}

	}
}
