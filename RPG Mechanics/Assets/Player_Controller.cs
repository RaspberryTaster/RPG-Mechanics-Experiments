using Assets.Battles;
using Assets.Units;
using NaughtyAttributes;
using Raspberry.Events;
using Raspberry.Movement;
using UnityEngine;
public enum Command_Type
{
	No_Targets, Single_Target
}
[CreateAssetMenu]
public class Player_Controller : ScriptableObject
{
	public Unit Current_Unit;
	public Queue_Component queue_Component;
	public Movement_Component movement_Component;
	public Targeting_Component Targeting_Component;
	public Event_Broadcaster Current_Unit_Event;
	public Battle_Order_Manager order_Manager;
	public Command_Type Command_Type;


	public delegate void Casting();
	public event Casting On_Casting;
	bool current_Unit_Turn => order_Manager.Current_Unit == Current_Unit && Current_Unit != null;
	public void Select_Unit (Unit unit)
	{
		Clear();
		if(unit != null)
		{
			Current_Unit = unit;

			Targeting_Component targeting_Component = Current_Unit.GetComponent<Targeting_Component>();
			if (targeting_Component != null)
			{
				Targeting_Component = targeting_Component;
			}

			Queue_Component queue_Component1 = Current_Unit.GetComponent<Queue_Component>();
			if (queue_Component1 != null)
			{
				queue_Component = queue_Component1;
			}

			Movement_Component movement_Component1 = Current_Unit.GetComponent<Movement_Component>();
			if (movement_Component1 != null)
			{
				movement_Component = movement_Component1;
			}


		}

		Current_Unit_Event.Raise();

	}
	[Button("Clear", EButtonEnableMode.Always)]
	public void Clear()
	{
		Current_Unit = null;
		Targeting_Component = null;
		queue_Component = null;
		movement_Component = null;
		Current_Unit_Event.Raise();
	}

	[Button("Execute Command", EButtonEnableMode.Always)]
	public void Command_Function()
	{
		if(current_Unit_Turn)
		{
			Debug.Log(Current_Unit + " will execute the command.");
			if(Command_Type == Command_Type.No_Targets)
			{
				Debug.Log(Current_Unit + " has executed no target command.");
			}
			else if(Command_Type == Command_Type.Single_Target && Targeting_Component != null)
			{
				Targeting_Component.On_Casting(Command_Type);
				On_Casting.Invoke();
			}
			else
			{
				Debug.LogWarning("No targeting component on unit, could not execute");
			}
		}
		else if (Current_Unit != null)
		{
			Debug.LogWarning("Not " + Current_Unit + "'s turn, can't execute the command.");
		}
		else
		{
			Debug.LogWarning("Not anyone's turn, can't execute the command");
		}
	}
}
