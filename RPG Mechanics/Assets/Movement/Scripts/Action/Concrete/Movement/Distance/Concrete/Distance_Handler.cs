using Raspberry.Movement;
using UnityEngine;

	namespace Raspberry.Movement
	{
		public class Distance_Handler : IDistance
		{
			ITarget self;
			ITarget target;
			Vector3 self_Position;
			Vector3 target_Position;
			IAction_Intent move_Intent;

			public Distance_Handler(ITarget target1, ITarget target2, IAction_Intent move_Intent)
			{
				this.self = target1;
				this.target = target2;
				this.move_Intent = move_Intent;
			}

			public float Distance(Vector3 t1, Vector3 t2)
			{
				return Vector3.Distance(t1, t2);
			}

			public bool Is_Within_Distance(ITarget self, ITarget target)
			{
				Change_Target(ref this.self, self);
				Change_Target(ref this.target, target);

				this.self.Set_Position(ref self_Position);
				this.target.Set_Position(ref target_Position);
				float distance = Distance(self_Position, target_Position);
				float effective_Range = Effective_Range();
				bool Is_Within_Distance = distance <= effective_Range;
				//Debug.Log(distance + " " + effective_Range);
				return Is_Within_Distance;
			}

			public float Effective_Range()
			{
				float value = move_Intent.Effective_Range();
				return value;
			}

			private void Change_Target(ref ITarget thing_Being_Changed, ITarget target)
			{
				thing_Being_Changed = target;
			}
		}
	}
