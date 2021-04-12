using Assets.Event_Managment.Runtimeset;
using Raspberry.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Units
{
	[CreateAssetMenu(menuName = "Unit/Runtime Set")]
	public class Unit_Runtime_Set : Runtime_Set<Unit>
	{
		public Observer Event_Listener = new Observer();
		private void OnEnable()
		{
			Event_Listener.Register();
		}
		private void OnDisable()
		{
			Event_Listener.Unegister();
		}
	}
}
