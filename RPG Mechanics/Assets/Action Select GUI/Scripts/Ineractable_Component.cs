using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{
	public class Ineractable_Component : MonoBehaviour, IInteractable
	{
		private IInteractable interactable_State = new Interactable();
		public bool walkable;
		public List<IExecutable> Interact(List<IInsitagtor_Intent> intents)
		{
			List<IExecutable> executables = new List<IExecutable>();
			for(int i = 0; i < intents.Count; i++)
			{
				executables = intents[i].Execute(executables);
			}

			return executables;
		}

		public List<IExecutable> Alt_Interact(IInstigator instigator)
		{
			List<IExecutable> executables = new List<IExecutable>();
			Debug.Log(walkable);
			if (walkable)
			{
				Debug.Log("Hey people can walk on me");
				if (instigator.Can_Walk)
				{
					Debug.Log("You seem to be capable of walking " + instigator);
					executables.Add(new Executable_Go_To(instigator, transform.position));
				}
			}
			return executables;
		}
	}
}
