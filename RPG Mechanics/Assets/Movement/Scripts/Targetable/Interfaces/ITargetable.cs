namespace Raspberry.Movement
{
	public interface ITargetable
	{
		void Targeted_For_Destination(Player_Input playerInput, IRange range, ITraversal_Method traversal_Method);
	}
}
