using Assets.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Battles
{
	[Serializable]
	public class Battle_Instance
	{
		public int Current_Round = 0;
		public List<Unit> Units = new List<Unit>();

		public Battle_Instance(List<Unit> units)
		{
			Units = units;
		}
	}
}
