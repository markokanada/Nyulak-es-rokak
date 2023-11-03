using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTL_NyulakEsRokak
{
	public class IntArrayEqualityComparer : IEqualityComparer<int[]>
	{
		public bool Equals(int[] x, int[] y)
		{
			if (x == null || y == null)
			{
				return x == y;
			}

			if (x.Length != y.Length)
			{
				return false;
			}

			for (int i = 0; i < x.Length; i++)
			{
				if (x[i] != y[i])
				{
					return false;
				}
			}

			return true;
		}

		public int GetHashCode(int[] obj)
		{
			int hash = 17;
			foreach (int element in obj)
			{
				hash = hash * 31 + element.GetHashCode();
			}
			return hash;
		}
	}

}
