using Assets.Action.Interfaces;
using Assets.Queue.Enums;
using Assets.Queue.Interfaces;

namespace Assets.Queue.Concrete
{
	public class Queue_Null : IQueue
	{
		public void Add(IAction action, Action_Types action_Types)
		{

		}

		public void Change_Strategy(IQueue queue)
		{

		}

		public void Delay_Action_With_Action(IAction delayedAction, IAction action, Action_Types action_Types)
		{

		}

		public void Dequeue(IAction action)
		{

		}

		public void Dequeue_All()
		{

		}

		public void Insert_To_Action_Queue(IAction action, Action_Types action_Types, int acitonIndex)
		{

		}

		public void Action_Start(IAction action)
		{

		}

		public void Action_Update(IAction action)
		{

		}

		public void Start_First_In_Line()
		{

		}

		public void Start_If_First_In_Line(IAction action)
		{

		}
	}
}
