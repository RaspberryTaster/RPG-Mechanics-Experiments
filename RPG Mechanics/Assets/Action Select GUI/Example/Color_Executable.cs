using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets
{
	public class Color_Executable : IExecutable
	{
		private string name;

		public Color_Executable(string name)
		{
			this.name = name;
		}

		public string Name => name;

		public void Execute()
		{
			
		}
	}
}
