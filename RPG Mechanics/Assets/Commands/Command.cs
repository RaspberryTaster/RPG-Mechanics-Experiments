using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Commands
{
	public class Command : Command_Base
	{
		public override void Execute()
		{
			Debug.Log("Executed");
		}

		public override void Undo()
		{
			Debug.Log("Undone");
		}
	}
}
