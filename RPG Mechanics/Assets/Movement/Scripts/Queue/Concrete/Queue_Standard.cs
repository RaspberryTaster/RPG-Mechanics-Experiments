using Assets.Action.Interfaces;
using Assets.Interfaces.Strategy;
using Assets.Queue.Enums;
using Assets.Queue.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Queue.Concrete
{
	public class Queue_Standard : IQueue, IStrategy<IQueue>
	{
		List<IAction> actions;
		List<Action_Types> actionNames;
		Queue_Component queue_Component;

		public Queue_Standard(List<IAction> actions, List<Action_Types> actionNames, Queue_Component queue_Component)
		{
			this.actions = actions;
			this.actionNames = actionNames;
			this.queue_Component = queue_Component;
		}

		public void Add(IAction action, Action_Types action_Types)
		{
			actions.Add(action);
			actionNames.Add(action_Types);
			Start_If_First_In_Line(action);
		}

		public void Start_If_First_In_Line(IAction action)
		{
			if (actions.IndexOf(action) == 0)
			{
				Start_First_In_Line();
			}
		}

		public void Start_First_In_Line()
		{
			if (actions.Count >= 1)
			{
				actions[0].Start();
			}
		}

		public void Change_Strategy(IQueue queue)
		{
			queue_Component.Change_Strategy(queue);
		}


		public void Dequeue(IAction action)
		{
			actionNames.RemoveAt(actions.IndexOf(action));
			actions.Remove(action);
		}

		public void Dequeue_All()
		{
			int count = actions.Count;
			for (int i = 0; i < count; i++)
			{
				actions[0].Exit();
			}
		}

		public void Delay_Action_With_Action(IAction delayedAction, IAction action, Action_Types action_Types)
		{
			int actionIndex = actions.IndexOf(delayedAction);
			Insert_To_Action_Queue(action, action_Types, actionIndex);
		}

		public void Insert_To_Action_Queue(IAction action, Action_Types action_Types, int actionIndex)
		{
			actions.Insert(actionIndex, action);
			actionNames.Insert(actionIndex, action_Types);
			Start_If_First_In_Line(action);
		}

		public void Action_Start(IAction action)
		{
			if (action == null) return;
			action.Start();
		}

		public void Action_Update(IAction action)
		{
			if (action == null) return;
			action.Update();
		}
	}
}
