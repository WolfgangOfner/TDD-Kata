using System.Collections.Generic;
using System.Linq;

namespace ListComparator
{
    public class ListComparator
    {
        public int Compare(IEnumerable<int> ints, IEnumerable<int> list)
        {
            return ints.Intersect(list).Count();
        }
    }
}