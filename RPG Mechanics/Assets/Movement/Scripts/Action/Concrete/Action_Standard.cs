using Assets.Action.Interfaces;
using Assets.Interfaces.Strategy;
using Assets.Queue.Interfaces;
using UnityEngine;

namespace Raspberry.Movement
{
	public class Action_Standard : IAction, IStrategy<IAction>
	{

		IAction cur_Action_Strategy;
		IQueue queue;

		public Action_Standard(IAction cur_Action_Strategy, IQueue queue)
		{
			this.cur_Action_Strategy = cur_Action_Strategy;
			this.queue = queue;
		}

		public Action_Standard(IQueue queue)
		{
			this.queue = queue;
		}

		public void Start()
		{
			Debug.Log("Start");
		}

		public void Update()
		{
			cur_Action_Strategy.Update();
		}

		public void Exit()
		{
			queue.Dequeue(this);
		}

		public void Change_Strategy(IAction action_Strategy)
		{
			cur_Action_Strategy = action_Strategy;
		}
	}
}
