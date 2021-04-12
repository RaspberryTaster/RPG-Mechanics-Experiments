using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Commands
{
	public class Limited_Command : Command_Base
	{
		public Command_Limiter Command_Limiter;
		public int Action_Cost;

		public Limited_Command(Command_Limiter command_Limiter, int action_Cost)
		{
			Command_Limiter = command_Limiter;
			Action_Cost = action_Cost;
		}

		public override void Execute()
		{
			bool Has_Required_Action_Points = Command_Limiter != null && Command_Limiter?.Action_Points >= Action_Cost;
			if (Has_Required_Action_Points)
			{
				Command_Limiter.Action_Points -= Action_Cost;
				Debug.Log("Executed command at " + Action_Cost);
			}
		}

		public override void Undo()
		{
			bool Can_Refund = Command_Limiter != null && Command_Limiter.Action_Points < int.MaxValue;
			if (Can_Refund)
			{
				Command_Limiter.Action_Points += Action_Cost;
				Debug.Log("Undone the command refunded " + Action_Cost);
			}
		}
	}
}
