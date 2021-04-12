using NaughtyAttributes;
using Raspberry.Events;
using UnityEngine;

namespace Assets.Battles
{
	[CreateAssetMenu(menuName = "Turnbased/ Battle Manager/ Round Manager")]
	public class Battle_Round_Manager : ScriptableObject
	{
		public int Current_Round;
		public Observer[] observers = new Observer[0];
		public void OnEnable()
		{
			if (observers == null || observers.Length == 0) return;
			int length = observers.Length;
			for (int i = 0; i < length; i++)
			{
				observers[i].Register();
			}
		}

		public void OnDisable()
		{
			if (observers == null || observers.Length == 0) return;
			int length = observers.Length;
			for (int i = 0; i < length; i++)
			{
				observers[i].Unegister();
			}
		}
		public void Set_Round(int round)
		{
			Current_Round = round;
		}
		[Button("Next Round", EButtonEnableMode.Always)]
		public void Next_Round()
		{
			Debug.Log("NEXT_ROUND");
			Current_Round++;
		}
		[Button("Reset Round", EButtonEnableMode.Always)]
		public void Reset_Round()
		{
			Debug.Log("Reset_Round");
			Set_Round(0);
		}
	}
}
