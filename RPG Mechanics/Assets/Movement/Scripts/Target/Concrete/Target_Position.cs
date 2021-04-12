using Assets.Action.Interfaces;
using Raspberry.Movement;
using Raspberry.Movement;
using Assets.Interfaces;
using Raspberry.Movement;
using UnityEngine;

namespace Raspberry.Movement
{
	public class Target_Position : ITarget, IHave_Position
	{
		Vector3 position;
		IRange range_Values;

		public Target_Position(Vector3 position, IRange rangeValues)
		{
			this.position = position;
			range_Values = rangeValues;
		}

		public void Face_Target(IRotate rotate)
		{
			rotate.Face_Target(Get_Position());
		}

		public bool Is_Facing_Target(IRotate rotate)
		{
			return rotate.Is_Facing_Target(Get_Position());
		}
		public void Set_Destination(IMovement movement)
		{
			movement.Set_Destination(Get_Position());
		}

		public void Set_Position(ref Vector3 position)
		{
			position = Get_Position();
		}

		public Vector3 Get_Position()
		{
			return position;
		}

		public void Set_Range_Values(ref IRange range_Values)
		{
			range_Values = this.range_Values;
		}

		public string To_String()
		{
			return "Position" + Get_Position();
		}

		public void Set_Position(IRequire_Position require_Position)
		{
			require_Position.Set_Position(Get_Position());
		}
	}
}
