using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsDataStructureCourse.Algorithms
{
    public class HowSum
    {
        public static List<int> howSum(int targetSum, int[] numbers, Dictionary<int, List<int>> memo = null)
        {
            if (memo == null)
            {
                memo = new Dictionary<int, List<int>>();
            }

            if (memo.ContainsKey(targetSum))
            {
                return memo[targetSum];
            }

            List<int> result = new List<int>();


            if(targetSum < 0)
            {
                return null;
            }

            if (targetSum == 0)
            {
                return result;
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                List<int> recursiveResult = howSum(targetSum - numbers[i], numbers, memo);
                if (recursiveResult != null)
                {
                    result.AddRange(recursiveResult);
                    result.Add(numbers[i]);
                    memo[targetSum] = result;
                    return memo[targetSum];
                }
                
            }

            memo[targetSum] = null;
            return null;
        }
    }
}
