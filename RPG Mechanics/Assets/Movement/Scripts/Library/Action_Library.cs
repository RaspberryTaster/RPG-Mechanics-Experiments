using Raspberry.Movement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Movement.Scripts.Library
{
	public static class Action_Library
	{
		public static float Effective_Range_Interaction(ITarget self, ITarget target,ref IRange target_Range_Values, ref IRange self_Range_Values)
		{
			self.Set_Range_Values(ref target_Range_Values);
			target.Set_Range_Values(ref self_Range_Values);
			float RadiusBuffer = (self_Range_Values.Get_Gameplay_Radius() * 0.2f);
			float newRange = target_Range_Values.Get_InteractionRadius() - RadiusBuffer;
			return newRange >= target_Range_Values.Get_Gameplay_Radius() ? newRange : target_Range_Values.Get_Gameplay_Radius();
		}

		public static float Effective_Range_Attacking(ITarget self, ITarget target, ref IRange target_Range_Values, ref IRange self_Range_Values)
		{
			self.Set_Range_Values(ref target_Range_Values);
			target.Set_Range_Values(ref self_Range_Values);
			float RadiusBuffer = (self_Range_Values.Get_Gameplay_Radius() * 0.2f);
			float newRange = target_Range_Values.Get_Attack_Radius() - RadiusBuffer;
			return newRange >= target_Range_Values.Get_Gameplay_Radius() ? newRange : target_Range_Values.Get_Gameplay_Radius();
		}
	}
}
