using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{
	public class Executable_Go_To : IExecutable
	{
		public IInstigator instigator;
		public Vector3 location;

		public Executable_Go_To(IInstigator instigator, Vector3 location)
		{
			this.instigator = instigator;
			this.location = location;
		}

		public string Name => "Go to";

		public void Execute()
		{
			Debug.Log(instigator + " is moving to " + location);	
		}
	}
}
