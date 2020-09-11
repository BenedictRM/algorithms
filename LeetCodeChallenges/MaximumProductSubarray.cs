// Given an integer array nums, find the contiguous subarray within an array (containing at least one number) which has the largest product.
// Example 1:

// Input: [2,3,-2,4]
// Output: 6
// Explanation: [2,3] has the largest product 6.
// Example 2:

// Input: [-2,0,-1]
// Output: 0
// Explanation: The result cannot be 2, because [-2,-1] is not a subarray.
using System;

namespace algorithms
{
    public class MaximumProductSubarray
    {
        public static int MaxProduct(int[] nums) {
            int max1 = findMax(nums);
            
            Array.Reverse(nums);
            int max2 = findMax(nums);

            Console.WriteLine("Max1: {0}, Max2: {1}", max1, max2);
            
            return Math.Max(max1, max2);
        }
        
        private static int findMax(int[] nums) {
            int max = nums[0];
            int[] memo = new int[nums.Length];
            
            memo[0] = nums[0];
            
            for(int i = 1; i < nums.Length; i++) {
                memo[i] = memo[i - 1] != 0 ? nums[i] * memo[i - 1] : nums[i];
                
                if(memo[i] > max)
                    max = memo[i];
            }
            
            return max;
        }
    }
}