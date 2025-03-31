using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsDataStructureCourse.Algorithms
{
    public class Fibonacci
    {
        public static BigInteger calculateFib(int number, Dictionary<int, BigInteger> memo = null)
        {
            BigInteger result;

            if (memo == null)
            {
                memo = new Dictionary<int, BigInteger>();
            }

            if (memo.ContainsKey(number))
            {
                return memo[number];
            }

            if (number <= 2)
            {
               return 1;
            }

            memo[number] = calculateFib(number - 1, memo) + calculateFib(number - 2, memo);

            return memo[number];
        }
    }
}
