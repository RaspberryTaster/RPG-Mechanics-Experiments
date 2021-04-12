using Assets.Commands;
using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Command_Component : MonoBehaviour
{
    public Command_Sequence Command_Sequence = new Command_Sequence();
    public Command_Base Command;
    public Command_Limiter Command_Limiter;

    [Button("Set Command", EButtonEnableMode.Always)]
    public void Set_Command()
	{
        Command = new Command();
	}
    [Button("Limited Command", EButtonEnableMode.Always)]
    public void Set_Limited_Command()
	{
        Command = new Limited_Command(Command_Limiter, 2);
    }
    [Button("Register", EButtonEnableMode.Always)]
    public void Register()
	{
        Command_Sequence.Register(Command);
	}
    [Button("Next Command", EButtonEnableMode.Always)]
    public void Next_Command()
	{
        Command_Sequence.Next_Command();
        Debug.Log(Command_Sequence.ToString());
	}
    [Button("Undo", EButtonEnableMode.Always)]
    public void Undo()
	{
        Command_Sequence.Undo_Command();
        Debug.Log(Command_Sequence.ToString());
    }

    [Button("Reset", EButtonEnableMode.Always)]
    public void Reset()
    {
        Command_Sequence.Reset();
        Debug.Log(Command_Sequence.ToString());
    }
}
