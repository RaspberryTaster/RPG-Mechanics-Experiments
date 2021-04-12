using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Tools.GameObjects
{
	public class GameObject_Extender : MonoBehaviour
	{
		public bool IsActive;
		public void OnEnable()
		{
			IsActive = true;
		}

		public void OnDisable()
		{
			IsActive = false;
		}
	}
}
