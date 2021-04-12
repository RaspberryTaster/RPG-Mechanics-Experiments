using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Interfaces.Strategy
{
	public interface IStrategy<Strategy>
	{
		void Change_Strategy(Strategy selected_Stratgy);
	}
}
