using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsDataStructureCourse.Algorithms
{
    public class CanSum
    {
        public static bool canSum(int targetSum, int[] numbers, Dictionary<int,bool> memo = null)
        {
            if(memo == null)
            {
                memo = new Dictionary<int,bool>();
            }

            if (memo.ContainsKey(targetSum))
            {
                return memo[targetSum];
            }

            if (targetSum == 0)
            {
                return true;
            }

            for(int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] <= targetSum)
                {
                    memo[targetSum] = canSum(targetSum - numbers[i], numbers, memo);
                    if (memo[targetSum])
                    {
                        return memo[targetSum];
                    }
                }
            }

            return false;
        }
    }
}
