using Assets.Interfaces.Strategy;

namespace Assets.Action.Interfaces
{
	public interface IAction : IStart, IUpdate, IExit
	{
	}
}
