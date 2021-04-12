using Raspberry.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Event_Managment.Listeners
{
	public class Observer_Component : MonoBehaviour
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
