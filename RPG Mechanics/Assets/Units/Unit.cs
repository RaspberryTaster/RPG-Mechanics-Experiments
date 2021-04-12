using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Units
{
	public class Unit : MonoBehaviour, IHave_Initative
	{
		public Unit_Runtime_Set Unit_Runtime_Set;
		public int Team;
		[SerializeField] int initative = 0;

		public int Initative => initative;


		private void Awake()
		{
			Add_To_Runtimeset();
		}

		private void Add_To_Runtimeset()
		{
			Unit_Runtime_Set.Add(this);
		}
	}
}
