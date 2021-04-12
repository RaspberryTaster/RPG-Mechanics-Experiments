using Assets.Action.Interfaces;
using Assets.Queue.Interfaces;
using Raspberry.Movement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raspberry.Movement
{
	public class Action_Rotate : IAction
	{
		IRotate rotate;
		ITarget target;
		IQueue queue;

		public Action_Rotate(IRotate rotate, ITarget target, IQueue queue)
		{
			this.rotate = rotate;
			this.target = target;
			this.queue = queue;
		}

		public void Start()
		{
			if (rotate.Is_Facing_Target(target))
			{
				Exit();
			}
		}

		public void Update()
		{
			if (rotate.Is_Facing_Target(target))
			{
				Exit();
			}
			else
			{
				rotate.Face_Target(target);
			}
		}

		public void Exit()
		{
			queue.Dequeue(this);
		}
	}
}
