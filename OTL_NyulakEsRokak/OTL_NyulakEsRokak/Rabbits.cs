using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTL_NyulakEsRokak
{
	internal class Rabbits : Entyti
	{
		private int SatietyMeter;
		public static int NutritionScore = 3;
		public static int MaximumStepDistance = 1;
		//public int ID = 0;	

		public Rabbits(int satietyMeter)
		{
			SatietyMeter = satietyMeter;
			//ID += 1;
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

		public int[] Moving(Dictionary<int[], string> surroundings, Rabbits rabbit)
		{
			string s = "Fű csomó";
			if (surroundings.ContainsValue(s))
			{
				rabbit.EatingGrass(2);
				return surroundings.First(x => x.Value == s).Key;
			}
			else if (surroundings.ContainsValue("Zsenge Fű"))
			{
				rabbit.EatingGrass(1);
				return surroundings.First(x => x.Value == "Zsenge Fű").Key;
			}
			rabbit.DidntHadFood();
			return surroundings.First(x => x.Value == rabbit.ToString()).Key;
		}

		public override Map SimulatingRound(Map map)
		{
			Dictionary<int[], string> sorroundings = new Dictionary<int[], string>(new IntArrayEqualityComparer());
			for (int i = 0; map.GetWidth() > i; i++) 
			{
				for (int j = 0; j < map.GetHeight(); j++)
				{
					int[] ints = new int[] { i, j };
					sorroundings.Add(ints, map.entytis[i, j].ToString()!);
				}
			}
			foreach (var item in sorroundings.Where(x => x.Value == "nyúl"))
			{
				Rabbits rabbit = (Rabbits)map.entytis[item.Key[0], item.Key[1]];
				Dictionary<int[], string> surroundingsOut = new Dictionary<int[], string>(new IntArrayEqualityComparer());
				if ((item.Key[0] > 0 && item.Key[1] > 0) && (item.Key[0] < map.GetWidth() && item.Key[1] < map.GetHeight()))
				{

					int[] pos = new int[] { item.Key[0] - 1, item.Key[1]};
					Console.WriteLine(sorroundings[pos]); ;
                    surroundingsOut.Add(pos, sorroundings[pos]);
					
					pos = item.Key;
					surroundingsOut.Add(pos, rabbit.ToString());

					pos[0] = item.Key[0];
					pos[1] = item.Key[1] - 1;
					surroundingsOut.Add(pos, sorroundings[pos]);

					pos[0] = item.Key[0] + 1;
					pos[1] = item.Key[1];
					surroundingsOut.Add(pos, sorroundings[pos]);

					pos[0] = item.Key[0];
					pos[1] = item.Key[1] + 1; 
					surroundingsOut.Add(pos, sorroundings[pos]);

					
				}
				int[] newPos = rabbit.Moving(surroundingsOut, rabbit);
				if (newPos[0] == item.Key[0] && newPos[1] == item.Key[1])
				{
					if (rabbit.SatietyMeter <= 0)
					{
						map.entytis[item.Key[0], item.Key[1]] = new Grass(0);
						sorroundings[item.Key] = map.entytis[item.Key[0], item.Key[1]].ToString()!;
					}
				}
				else
				{
					map.entytis[newPos[0], newPos[1]] = rabbit;
                    map.entytis[item.Key[0], item.Key[1]] = new Grass(0);
					sorroundings[newPos] = rabbit.ToString();
					sorroundings[item.Key] = map.entytis[item.Key[0], item.Key[1]].ToString()!;
				}
			}
			return map;
		}

		public override string ToString()
		{
			return "nyúl";// + ID;
		}
	}
}
