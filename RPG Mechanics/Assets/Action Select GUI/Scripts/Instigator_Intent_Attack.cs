using Raspberry.Movement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{
	public class Instigator_Intent_Attack : IInsitagtor_Intent
	{
		private IInstigator instigator;
		private Body_Component Body_Component;
		private ITarget target;
		private ITraversal_Method traversal_Method;

		public Instigator_Intent_Attack(IInstigator instigator, Body_Component body_Component, ITarget target, ITraversal_Method traversal_Method)
		{
			this.instigator = instigator;
			Body_Component = body_Component;
			this.target = target;
			this.traversal_Method = traversal_Method;
		}

		public List<IExecutable> Execute(List<IExecutable> executables)
		{
			for (int I = 0; I < Body_Component.Vitals.Body_Parts.Count; I++)
			{
				Body_Part body_Part = Body_Component.Vitals.Body_Parts[I];
				if(body_Part == null)
				{
					Debug.Log("a bodypart was null");
				}
				else
				{
					executables.Add(new Executable_Limb(instigator, Body_Component, traversal_Method, target, body_Part));
				}

			}

			for (int I = 0; I < Body_Component.Non_Vital.Body_Parts.Count; I++)
			{
				Body_Part body_Part = Body_Component.Non_Vital.Body_Parts[I];
				if (body_Part == null)
				{
					Debug.Log("a bodypart was null");
				}
				else
				{
					executables.Add(new Executable_Limb(instigator, Body_Component, traversal_Method, target, body_Part));
				}
			}
			return executables;
		}
	}
}
