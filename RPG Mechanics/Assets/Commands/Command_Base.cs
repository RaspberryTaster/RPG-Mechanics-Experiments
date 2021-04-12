using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Commands
{
	public abstract class Command_Base
	{
		public bool disable_Undo;
		public abstract void Execute();
		public abstract void Undo();
	}
}
