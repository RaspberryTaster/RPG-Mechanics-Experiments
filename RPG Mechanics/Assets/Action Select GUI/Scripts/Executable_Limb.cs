using Assets.Queue.Enums;
using Raspberry.Movement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{
	[Serializable]
	public class Executable_Limb : IExecutable
	{
		public IInstigator instigator;
		public Body_Component body_Component;
		public ITraversal_Method traversal_Method;
		public ITarget target;
		public Body_Part Body_Part;

		public Executable_Limb(IInstigator instigator, Body_Component body_Component, ITraversal_Method traversal_Method, ITarget target, Body_Part body_Part)
		{
			this.instigator = instigator;
			this.body_Component = body_Component;
			this.traversal_Method = traversal_Method;
			this.target = target;
			Body_Part = body_Part;
		}

		public string Name => Body_Part.Name;

		public void Execute()
		{
			Debug.Log($"{instigator} attacked, {Body_Part.Name}");
			IAction_Intent move_Intent = new Intent_Attacking(instigator.Movement_Component.self,body_Component, Body_Part);
			instigator.Movement_Component.Move(target, traversal_Method, move_Intent, Action_Types.OBJECT_MOVE);
		}
	}
}
