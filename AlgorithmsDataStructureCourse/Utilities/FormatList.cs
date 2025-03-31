using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsDataStructureCourse.Utilities
{
    public class FormatList
    {
        public static string formatList(List<int> list)
        {
            if (list == null)
            {
                return "null";
            }
            return "[" + string.Join(",", list) + "]";
        }
    }
}
