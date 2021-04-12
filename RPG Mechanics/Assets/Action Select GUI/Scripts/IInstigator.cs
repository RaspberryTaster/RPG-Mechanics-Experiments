using Raspberry.Movement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets
{
	public interface IInstigator
	{
		bool Can_Walk { get; }
		Movement_Component Movement_Component { get; }
	}
}
