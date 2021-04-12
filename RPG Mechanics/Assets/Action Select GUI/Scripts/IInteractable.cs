﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets
{
	public interface IInteractable
	{
		List<IExecutable> Interact(List<IInsitagtor_Intent> intents);
		List<IExecutable> Alt_Interact(IInstigator instigator);
	}
}
