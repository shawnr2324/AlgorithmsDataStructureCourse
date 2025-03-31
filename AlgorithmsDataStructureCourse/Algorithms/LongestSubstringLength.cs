using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsDataStructureCourse.Algorithms
{
    public class LongestSubstringLength
    {
        public static int getLongestSubstringCount_brute(string inputString, Dictionary<char,int> characters = null)
        {
            int currentSubstringLength = 0;
            int maxSubstringLength = 0;
            if (inputString.Length == 1)
            {
                return 1;
            }

            if (characters == null)
            {
                characters = new Dictionary<char, int>();
            }

            for (int i = 0; i < inputString.Length; i++)
            {
                for (int j = i; j < inputString.Length; j++)
                {
                    if (characters.ContainsKey(inputString[j]))
                    {
                        characters.Clear();
                        currentSubstringLength = 0;
                        break;
                    }
                    characters.Add(inputString[j], j);
                    currentSubstringLength++;
                    maxSubstringLength = Math.Max(maxSubstringLength, currentSubstringLength);
                }
                
            }

            return maxSubstringLength;
        }

        public static int getLongestSubstringCount_tab(string inputString, Dictionary<char, int> characters = null)
        {
            //TODO: Tabulation
            return 0;
        }
    }
}
