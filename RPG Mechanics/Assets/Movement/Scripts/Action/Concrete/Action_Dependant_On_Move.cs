using Assets.Action.Interfaces;
using Assets.Action.Rotate;
using Assets.Queue.Enums;
using Assets.Queue.Interfaces;
using Raspberry.Movement;
using UnityEngine;

namespace Raspberry.Movement
{
	public class Action_Dependant_On_Move : IAction
	{
		IRotate rotate;
		IQueue queue;
		Movement_Handler movement_Manager;
		IDistance distance;
		ITarget self;	
		IAction_Intent action_Intent;
		ITarget target;
		ITraversal_Method traversal_Method;

		public Action_Dependant_On_Move(IQueue queue, Movement_Handler movement_Manager, ITarget target, ITraversal_Method traversal_Method, ITarget self, IAction_Intent move_Intent, GameObject self_GameObject)
		{
			this.queue = queue;
			this.movement_Manager = movement_Manager;
			this.target = target;
			this.traversal_Method = traversal_Method;
			this.self = self;
			this.action_Intent = move_Intent;
			distance = new Distance_Handler(self, target, move_Intent);
			rotate = new Rotation_Handler(self_GameObject,self);
		}

		public void Start()
		{
			if (!distance.Is_Within_Distance(self, target))
			{
				queue.Delay_Action_With_Action(this, new Action_Move(queue, movement_Manager, target, traversal_Method, self, action_Intent), Action_Types.DELAY_WITH_MOVE);
			}
			else if (!rotate.Is_Facing_Target(target))
			{
				queue.Delay_Action_With_Action(this, new Action_Rotate(rotate, target, queue), Action_Types.DELAY_WITH_ROTATION);
			}
		}

		public void Update()
		{
			if (!distance.Is_Within_Distance(self, target))
			{
				queue.Delay_Action_With_Action(this, new Action_Move(queue, movement_Manager, target, traversal_Method, self, action_Intent), Action_Types.DELAY_WITH_MOVE);
			}
			else if (!rotate.Is_Facing_Target(target))
			{
				queue.Delay_Action_With_Action(this, new Action_Rotate(rotate, target, queue), Action_Types.DELAY_WITH_ROTATION);
			}
			else
			{
				action_Intent.Execute();
				Exit();
			}

		}
		public void Exit()
		{
			queue.Dequeue(this);
		}
	}
}
