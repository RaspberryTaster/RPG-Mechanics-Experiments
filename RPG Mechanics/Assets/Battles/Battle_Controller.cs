using Assets.Tools.GameObjects;
using Assets.Tools.Object_Pooling;
using Assets.Units;
using NaughtyAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Battles
{
	public class Battle_Controller : MonoBehaviour
	{
		public GameObject battle_Collider;
		public Object_Pool_Component battle_Collider_Pool;
		public Battle_Order_Manager Battle_Order_Manager;
		public void Spawn_Battle_Colllider()
		{
			if(battle_Collider != null)
			{
				battle_Collider.SetActive(false);
			}
			battle_Collider = battle_Collider_Pool.GetPooledObject(0);
			battle_Collider.transform.position = transform.position;
			battle_Collider.SetActive(true);
		}
	}
}
