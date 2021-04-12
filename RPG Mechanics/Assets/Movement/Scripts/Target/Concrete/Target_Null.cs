using Assets.Action.Interfaces;
using Raspberry.Movement;
using UnityEngine;

namespace Raspberry.Movement
{
	public class Target_Null : ITarget
	{
		public void Face_Target(IRotate rotate)
		{

		}
		public bool Is_Facing_Target(IRotate rotate)
		{
			return false;
		}

		public bool Is_Within_Distance(IDistance distance)
		{
			return false;
		}

		public string To_String()
		{
			return "Null";
		}

		public void Set_Destination(IMovement movement)
		{

		}

		public void Set_Position(IDistance distance)
		{

		}

		public void Set_Position(ref Vector3 position)
		{

		}

		public void Set_Range_Values(ref IRange range)
		{

		}

		public void Set_Position(IRequire_Position require_Position)
		{

		}
	}
}
