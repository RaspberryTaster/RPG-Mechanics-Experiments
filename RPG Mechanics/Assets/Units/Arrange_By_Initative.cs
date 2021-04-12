using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Units
{
    public class Arrange_By_Initative : IComparer<IHave_Initative>
    {
        public int Compare(IHave_Initative x, IHave_Initative y)
        {
            if (x == null || y == null)
            {
                return 0;
            }

            return x.Initative.CompareTo(y.Initative);
        }
    }
}
