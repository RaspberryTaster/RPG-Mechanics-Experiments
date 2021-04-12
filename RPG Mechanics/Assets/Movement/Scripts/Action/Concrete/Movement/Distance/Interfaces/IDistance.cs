using Raspberry.Movement;
using UnityEngine;

namespace Raspberry.Movement
{
	public interface IDistance
	{
		float Distance(Vector3 t1, Vector3 t2);
		bool Is_Within_Distance(ITarget self, ITarget target);
		float Effective_Range();

	}
}
