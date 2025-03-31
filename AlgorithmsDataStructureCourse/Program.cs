using System;
using AlgorithmsDataStructureCourse.Models;
using AlgorithmsDataStructureCourse.Algorithms;
using AlgorithmsDataStructureCourse.Utilities;
using System.Numerics;

namespace AlgorithmsDataStructureCourse
{
    class Programs
    {
        public static void Main(string[] args)
        {
            Pokemon squirtle = new Pokemon("squirtle", 100);

            //Fibonacci
            //Console.WriteLine(Fibonacci.calculateFib(100));
            //Console.WriteLine(Fibonacci.calculateFib(6));
            //Console.WriteLine(Fibonacci.calculateFib(10));

            //Grid Traveler
            //Console.WriteLine(GridTraveler.gridTraveler(1, 1));
            //Console.WriteLine(GridTraveler.gridTraveler(2, 3));
            //Console.WriteLine(GridTraveler.gridTraveler(3, 2));
            //Console.WriteLine(GridTraveler.gridTraveler(3,3));
            //Console.WriteLine(GridTraveler.gridTraveler(18, 18));

            //LongestSubstringLength
            //Console.WriteLine(LongestSubstringLength.getLongestSubstringCount_brute("abcdae")); //5
            //Console.WriteLine(LongestSubstringLength.getLongestSubstringCount_brute("abcabcbb")); //3
            //Console.WriteLine(LongestSubstringLength.getLongestSubstringCount_brute("bbbbb")); //1
            //Console.WriteLine(LongestSubstringLength.getLongestSubstringCount_brute("pwwkew")); //3
            //Console.WriteLine(LongestSubstringLength.getLongestSubstringCount_brute("abcajjabdwertyuiolkjhalkajsdfkjahwelukhaskldjfhlaksudhflkajshdflkjasdf")); //15

            //canSum_Bool
            //Console.WriteLine(CanSum.canSum(7, [5,3,4,7])); //True
            //Console.WriteLine(CanSum.canSum(9, [2, 4])); //False
            //Console.WriteLine(CanSum.canSum(9, [2, 1, 3])); //True
            //Console.WriteLine(CanSum.canSum(300, [7, 14])); //True

            //howSum
            Console.WriteLine(FormatList.formatList(HowSum.howSum(7, [2, 3]))); //[3, 2, 2]
            Console.WriteLine(FormatList.formatList(HowSum.howSum(7, [5, 3, 4, 7]))); //[4,3]
            Console.WriteLine(FormatList.formatList(HowSum.howSum(7, [2, 4]))); // null
            Console.WriteLine(FormatList.formatList(HowSum.howSum(8, [2, 3, 5]))); // [2, 2, 2, 2]
            Console.WriteLine(FormatList.formatList(HowSum.howSum(300, [7, 14]))); //null
        }


    }
}

