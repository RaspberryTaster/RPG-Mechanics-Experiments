using Raspberry.Movement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Action_Select_GUI.Scripts
{
	public class Instigator_Standard : IInstigator
	{
		public bool Can_Walk => true;

		private Movement_Component movement_Component;

		public Instigator_Standard(Movement_Component movement_Component)
		{
			this.movement_Component = movement_Component;
		}

		public Movement_Component Movement_Component => movement_Component;
	}
}
