using Assets.Units;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
	Casting, Neutral
}

public class Targeting_Component : MonoBehaviour
{
    public List<Unit> targets;
	public Unit[] previous_Targets;
	public Target_Executor target_Executor;


	public delegate void Casting();	
	public event Casting Is_Casting;
	public delegate void Interupting();
	public event Casting Is_Interupted;

	public State target_State = State.Neutral;
	//On the begining of casting call this.
	public void On_Casting(Command_Type command_Type)
	{
		target_Executor = new Target_Executor(command_Type, this);
		target_State = State.Casting;
		Debug.Log(gameObject.name + " has begun casting.");
		Is_Casting.Invoke();
	}
	public void Add_Target(Unit target)
	{
		targets.Add(target);
	}

	//On finishing casting call this
	public void On_Interrupt()
	{
		Send_To_Previous();
		targets.Clear();
		target_State = State.Neutral;
		Debug.Log(gameObject.name + " stopped casting.");
		Is_Interupted.Invoke();
	}
	public void Send_To_Previous()
	{
		previous_Targets = targets.ToArray();
	}
}

[System.Serializable]
public class Target_Executor
{
	public Command_Type command_Type;
	public Targeting_Component targeting_Component;
	public Target_Executor(Command_Type command_Type, Targeting_Component targeting_Component)
	{
		this.command_Type = command_Type;
		this.targeting_Component = targeting_Component;
	}

	public void Execute()
	{
		if(command_Type == Command_Type.Single_Target)
		{
			if(targeting_Component.targets.Count >= 0)
			{
				int count = targeting_Component.targets.Count;
				for (int i = 0; i < count; i++)
				{
					Debug.Log(targeting_Component.targets[i] + "has been targeted with a single target command.");
				}
				targeting_Component.On_Interrupt();
			}
			else
			{
				Debug.LogWarning("Not correct amount of targets");
			}
		}
	}
}
