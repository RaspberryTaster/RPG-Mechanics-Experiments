using Assets.Action.Interfaces;
using Assets.Interfaces.Name;
using UnityEngine;

namespace Raspberry.Movement
{
	public interface ITarget : IHave_Name
	{
		void Face_Target(IRotate rotate);
		bool Is_Facing_Target(IRotate rotate);
		void Set_Position(ref Vector3 position);
		void Set_Range_Values(ref IRange range_Values);
		void Set_Destination(IMovement movement);

		void Set_Position(IRequire_Position require_Position);
	}
}
