using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsDataStructureCourse.Algorithms
{
    public class GridTraveler
    {
        public static BigInteger gridTraveler(int m, int n, Dictionary<Tuple<int,int>, BigInteger> memo = null)
        {
            if (memo == null)
            {
                memo = new Dictionary<Tuple<int, int>, BigInteger>();
            }

            if (m == 0 || n == 0)
            {
                return 0;
            }

            if (m == 1 && n == 1)
            {
                return 1;
            }

            Tuple<int, int> keyToCheck = Tuple.Create(m, n);
            if (memo.ContainsKey(keyToCheck))
            {
                return memo[keyToCheck];
            }

            memo[keyToCheck] = gridTraveler(m-1, n, memo) + gridTraveler(m, n-1, memo);
            return memo[keyToCheck];
        }
    }
}
