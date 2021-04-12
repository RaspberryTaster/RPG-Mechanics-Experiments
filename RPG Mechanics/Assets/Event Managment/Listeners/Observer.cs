using MEC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace Raspberry.Events
{
	[Serializable]
	public class Observer
	{
		[SerializeField] private List<Event_Broadcaster> Events;
		[SerializeField] private UnityEvent Response;
		public float Delay_Time_In_Seconds;
		public int Execution_Order;
		public Observer()
		{
			Events = new List<Event_Broadcaster>();
		}
		public Observer(List<Event_Broadcaster> events, UnityEvent response, int execution_Order)
		{
			Events = events;
			Response = response;
			Execution_Order = execution_Order;
		}

		public void Register()
		{
			int count = Events.Count;
			for (int i = 0; i < count; i++)
			{
				Events[i].Register_Listener(this);
			}
		}

		public void Unegister()
		{
			int count = Events.Count;
			for (int i = 0; i < count; i++)
			{
				Events[i].Unregister_Listener(this);
			}
		}

		public void On_Event_Raised()
		{
			Timing.RunCoroutine(Delay());
		}

		IEnumerator<float> Delay()
		{
			yield return Timing.WaitForSeconds(Delay_Time_In_Seconds);
			if (Response != null)
			{
				Response.Invoke();
			}

		}
	}
}
