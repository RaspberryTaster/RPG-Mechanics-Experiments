using Raspberry.Movement;
using UnityEngine;

namespace Raspberry.Movement
{
	public interface IMovement
	{
		void Idle();
		void Set_Destination(ITarget target, ITraversal_Method traversal_Method);
		void Set_Destination(ITarget target);
		void Set_Destination(Vector3 postion);
	}
}
