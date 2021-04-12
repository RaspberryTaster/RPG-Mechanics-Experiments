using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets
{
	public class Executable_Versatile : IExecutable
	{
		private string name;

		public Executable_Versatile(string name)
		{
			this.name = name;
		}

		public string Name => name;

		public void Execute()
		{

		}
	}
}
