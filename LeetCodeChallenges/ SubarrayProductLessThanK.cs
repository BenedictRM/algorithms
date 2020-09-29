// Your are given an array of positive integers nums.

// Count and print the number of (contiguous) subarrays where the product of all the elements in the subarray is less than k.

// Example 1:
// Input: nums = [10, 5, 2, 6], k = 100
// Output: 8
// Explanation: The 8 subarrays that have product less than 100 are: [10], [5], [2], [6], [10, 5], [5, 2], [2, 6], [5, 2, 6].
// Note that [10, 5, 2] is not included as the product of 100 is not strictly less than k.

// Note:

// 0 < nums.length <= 50000.
// 0 < nums[i] < 1000.
// 0 <= k < 10^6.
using System;
using System.Collections.Generic;

namespace algorithms
{
    public class SubarrayProductLessThanK
    {
        // sliding window solution -- build subarrays until >= k, then slice off earlier idxs and continue processing
        public static int NumSubarrayProductLessThanK(int[] nums, int k) {
            int total = 0;
            int product = 1;
            int start = 0;
            
            for(int i = 0; i < nums.Length; i++ )
            {
                product *= nums[i];
                
                while(product >= k && start <= i )
                {
                    product /= nums[start++];
                }

                total += i - start + 1;//1,2,2,3 for sliding 
            }
            
            return total;
        }

        //This works but is not real efficient, hitting time limit exceptions
        // private static List<List<int>> subarrays;
        // public static int NumSubarrayProductLessThanK(int[] nums, int k) {
        //     subarrays = new List<List<int>>();

        //     int idx = 0;
        //     while(idx < nums.Length) {
        //         buildSubarrays(nums, k, idx, 1, new List<int>());
        //         idx++;
        //     }

        //     // foreach(List<int> subarray in subarrays){
        //     //     foreach(int i in subarray){
        //     //         Console.Write(i + " ");
        //     //     }
        //     //     Console.WriteLine();
        //     // }

        //     return subarrays.Count;
        // }

        // private static List<int> buildSubarrays(int[] nums, int k, int i, int total, List<int> subarray) {
        //     if(i < nums.Length && (nums[i] * total) < k){
        //         subarray.Add(nums[i]);

        //         List<int> subarrayclone = new List<int>();
        //         subarrayclone.AddRange(subarray);
        //         subarrays.Add(subarrayclone);

        //         total *= nums[i];
        //         i++;
        //         //recurse right building contiguous subarrays
        //         buildSubarrays(nums, k, i, total, subarray);
        //     }

        //     return subarray;
        // }
    }
}