using Assets.Movement.Scripts.Library;
using Raspberry.Movement;
using UnityEngine;

namespace Raspberry.Movement
{
	public class Intent_Spawn_Ball : IAction_Intent
	{
		ITarget self;
		ITarget target;
		IRange target_Range_Values = new Range_Null();
		IRange self_Range_Values = new Range_Null();

		public Spawn_A_Ball_ Spawn_A_Ball_;

		public Intent_Spawn_Ball(ITarget self, ITarget target, Spawn_A_Ball_ spawn = null)
		{
			this.self = self;
			this.target = target;
			Spawn_A_Ball_ = spawn;
		}

		public float Effective_Range()
		{
			return Action_Library.Effective_Range_Interaction(self, target, ref target_Range_Values, ref self_Range_Values);
		}

		public void Execute()
		{
			Debug.Log(self + " interacted with " + target);
			if(Spawn_A_Ball_ != null)
			{
				self.Set_Position(Spawn_A_Ball_);
			}
		}
	}
}
