using NaughtyAttributes;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;

namespace Raspberry.Events
{
	[CreateAssetMenu(menuName = "Events/Event Broadcaster")]
	public class Event_Broadcaster : ScriptableObject
	{
		private List<Observer> event_Listeners = new List<Observer>();
		public Observer Observer;

		private void OnEnable()
		{
			if (Observer == null) return;
			Observer.Register();
		}
		public void OnDisable()
		{
			Observer.Unegister();
		}
		[Button("Raise", EButtonEnableMode.Always)]
		public void Raise()
		{
			int count = event_Listeners.Count;
			for (int i = 0; i < count; i++)
			{
				Observer event_Listener = event_Listeners[i];
				event_Listener.On_Event_Raised();
			}	

		}
		public void Register_Listener(Observer observer)
		{
			if (!event_Listeners.Contains(observer))
				event_Listeners.Add(observer);
			Update_Order();
		}

		public void Unregister_Listener(Observer observer)
		{
			if (event_Listeners.Contains(observer))
				event_Listeners.Remove(observer);
		}

		private void Update_Order()
		{
			if (event_Listeners.Count > 1)
				event_Listeners = event_Listeners?.OrderBy(order => order.Execution_Order).ToList();
		}

	}
}
