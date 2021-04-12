
using UnityEngine;

namespace Raspberry.Movement
{
		public class Intent_None : IAction_Intent
		{
			public float range;

			public Intent_None(float range)
			{
				this.range = range;
			}

			public float Effective_Range()
			{
				return range;
			}

			public void Execute()
			{
				Debug.Log("I jus wanted to get closer :)");
			}
		}
}
