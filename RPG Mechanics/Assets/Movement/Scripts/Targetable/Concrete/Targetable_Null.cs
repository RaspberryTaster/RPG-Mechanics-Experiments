namespace Raspberry.Movement
{
	public class Targetable_Null : ITargetable
	{

		public void Targeted_For_Destination(Player_Input playerInput, IRange range, ITraversal_Method traversal_Method)
		{
			playerInput.SetEnviromentDestination(playerInput.cur_Mouse_Position, traversal_Method);
		}
	}
}
