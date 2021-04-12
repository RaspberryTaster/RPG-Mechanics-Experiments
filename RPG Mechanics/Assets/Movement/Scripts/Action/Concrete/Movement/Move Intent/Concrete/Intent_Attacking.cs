using Assets.Attacks;
using Assets.Damage_Types;
using Assets.Movement.Scripts.Library;
using Raspberry.Movement;
using UnityEngine;

namespace Raspberry.Movement
{
	public class Intent_Attacking : IAction_Intent
	{
		ITarget self;
		ITarget target;
		IRange target_Range_Values = new Range_Null();
		IRange self_Range_Values = new Range_Null();

		Body_Component target_Body;
		Body_Part target_Limb;

		public Intent_Attacking(ITarget self, Body_Component target_Body, Body_Part target_Limb)
		{
			this.self = self;
			this.target_Body = target_Body;
			this.target_Limb = target_Limb;
			IRange Range = target_Body.gameObject.GetComponent<Range_Component>();
			if (Range == null)
			{
				Range = new Range_Null();
			}
			target = new Target_GameObject(target_Body.gameObject, Range);
		}

		public float Effective_Range()
		{
			return Action_Library.Effective_Range_Attacking(self, target, ref target_Range_Values, ref self_Range_Values);
		}

		public void Execute()
		{
			IDamage[] damages = new IDamage[] { new Slash_Damage() };
			target_Body.Attack(target_Limb, new Damaging_Attack(10, damages));
			Debug.Log(self + " attacked " + target + "!");
			Debug.Log("Current Barrier Value: " + target_Body.Body_Combat.Barrier.Value);
			Debug.Log(target_Limb.To_String() + " Current Health Value: " + target_Limb.Health.Value);
			Debug.Log("Current Endurance Value: " + target_Body.Body_Combat.Endurance.Value);

		}
	}
}
