using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CSharpBasic
{
    public static class ControlStructureDemo
    {
       
        public static void DoControlStructureDemo()
        {
            // If-else statement
            int num = 10;
            if(num > 0)
            {
                Console.WriteLine("The number is positive");
            } else if(num < 0)
            {
                Console.WriteLine("The number is negative");
            } else
            {
                Console.WriteLine("The number is zero");
            }

            // Switch case 

            switch(num)
            {
                case 0: Console.WriteLine("The number is zero"); break;
            }


            // Loop: Loops allow you to execute a block of code repeatedly. There are several types of loops in C#.
            // for loop: The for loop is used when the number of interations is known 
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"Iteration {i}");
            }

            // While loop: The while loop is used when the number of interations is not known in advance
            int count = 0;
            while (count < 3)
            {
                Console.WriteLine($"Count: {count}");
                count++;
            }

            // Do-while loop: The do-while loop is similar to the while loop but guarantees that the loop body is executed atlest once. 
            int attempt = 0;
            do
            {
                Console.WriteLine($"Attempt: {attempt}");
                attempt++;
            } while (attempt < 3);


            // Foreach loop: The foreach loop is used to iterate over elements in a collection(e.g., arrays or lists).
            int[] numbers = { 1, 2, 3, 4, 5 };
            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }
        }



        public static void LeetCodeDemo()
        {
            var _ = TwoSumOptimalSolution([1, 3, 4, 5, 6], 11);
        }



        /// <summary>
        /// Apply if-else statement and loop to resolve a problem on LeetCode
        /// https://leetcode.com/problems/two-sum/
        /// </summary>
        public static int[] TwoSumDemoBruteForce(int[] nums, int target)
        {
            for(int i = 0; i < nums.Length; i++)
            {
                for(int j = i + 1; j < nums.Length; j ++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        Console.WriteLine($"Result [{i}, {j}]");
                        return [i, j];
                    }
                }
            }

            return [];

        }


        /// <summary>
        /// Reduce complexity using Hashmap (in this case is Dictionary)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int[] TwoSumOptimalSolution(int[] nums, int target)
        {
            Dictionary<int, int> hashMap = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                var valueToFind = target - nums[i];
                if (hashMap.ContainsKey(valueToFind))
                {
                    Console.WriteLine($"Result [{i}, {hashMap.GetValueOrDefault(valueToFind)}]");
                    return [hashMap.GetValueOrDefault(valueToFind), i];
                }
                else hashMap[nums[i]] = i;
            }

            return [];
        }


    }
}
