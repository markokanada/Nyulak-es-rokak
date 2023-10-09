using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTL_NyulakEsRokak
{
	internal class Grass
	{
		public Grass(int nutritionalValue)
		{
			NutritionalValue = nutritionalValue;
		}

		public int NutritionalValue { get; init; }

		public string GetTheTypeOfGrass()
		{
			if (this.NutritionalValue == 0) 
			{
				return "Fű kezdemény";
			}
			else if (this.NutritionalValue == 1)
			{
				return "Zsenge fű";
			}
			else if (this.NutritionalValue == 2)
			{
				return "Fű csomó";
			}
			return "";
		}

    }
}
