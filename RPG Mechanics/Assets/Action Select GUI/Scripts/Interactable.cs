using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets
{
	public class Interactable : IInteractable
	{
		public List<IExecutable> Alt_Interact(IInstigator instigator)
		{
			return null;
		}

		public List<IExecutable> Interact(List<IInsitagtor_Intent> insitagtor_Intents)
		{
			return null;
		}
	}
}
