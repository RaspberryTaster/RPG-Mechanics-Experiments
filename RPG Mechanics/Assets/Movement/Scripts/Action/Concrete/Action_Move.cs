using Assets.Action.Interfaces;
using Assets.Queue.Interfaces;
using Raspberry.Movement;

namespace Raspberry.Movement
{
	public class Action_Move : IAction
	{
		IQueue queue;
		Movement_Handler movement_Manager;
		IDistance distance;
		ITarget self;
		ITarget target;
		ITraversal_Method traversal_Method;

		public Action_Move(IQueue queue, Movement_Handler movement_Manager, ITarget target, ITraversal_Method traversal_Method, ITarget self, IAction_Intent move_Intent)
		{
			this.queue = queue;
			this.movement_Manager = movement_Manager;
			this.target = target;
			this.traversal_Method = traversal_Method;
			this.self = self;
			distance = new Distance_Handler(self, target, move_Intent);
		}

		public void Start()
		{
			if (distance.Is_Within_Distance(self, target))
			{
				Exit();
			}
			else
			{
				movement_Manager.Set_Destination(target, traversal_Method);
			}

		}

		public void Update()
		{
			if (distance.Is_Within_Distance(self, target))
			{
				Exit();
			}
		}

		public void Exit()
		{
			movement_Manager.Idle();
			queue.Dequeue(this);
		}
	}
}
