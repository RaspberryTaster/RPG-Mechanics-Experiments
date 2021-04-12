using Assets.Action.Interfaces;

namespace Assets.Queue.Interfaces
{
	public interface IDequeue
	{
		void Dequeue(IAction action);
		void Dequeue_All();
	}
}
