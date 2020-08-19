// Return all non-negative integers of length N such that the absolute difference between every two consecutive digits is K.
// Note that every number in the answer must not have leading zeros except for the number 0 itself. For example, 01 has one leading zero and is invalid, but 0 is valid.
// You may return the answer in any order.

//Example:
// Input: N = 2, K = 1
// Output: [10,12,21,23,32,34,43,45,54,56,65,67,76,78,87,89,98]

//Time LIMIT EXCEEDED with this solution -- issue: use Dynamic Programing to assemble the number rather than search for them


    // List<Integer> cur = Arrays.asList(0, 1, 2, 3, 4, 5, 6, 7, 8, 9);
    //     for (int i = 2; i <= N; ++i) {
    //         List<Integer> cur2 = new ArrayList<>();
    //         for (int x : cur) {
    //             int y = x % 10;
    //             if (x > 0 && y + K < 10)
    //                 cur2.add(x * 10 + y + K);
    //             if (x > 0 && K > 0 && y - K >= 0)
    //                 cur2.add(x * 10 + y - K);
    //         }
    //         cur = cur2;
    //     }
    //     return cur.stream().mapToInt(j->j).toArray();
using System;
using System.Collections.Generic;

namespace algorithms
{
    public class NumbersWithSameConsecutiveDifferences
    {
        public static int[] Solution(int N, int K) {
            List<int> integers = new List<int>();
            int i = (int)Math.Pow(10, N - 1);
            int max = (int)Math.Pow(10, N);

            if(N == 1)
                i--;

            while(i < max) {
                if(isValidInteger(i, K))
                    integers.Add(i);

                i++;
            }

            return integers.ToArray();
        }

        private static bool isValidInteger(int i, int K) {
            bool isValidInteger = true;
            int previous = -1;

            while(i > 0) {
                int digit = i % 10;

                if(previous >= 0){
                    if(Math.Abs(previous - digit) != K){
                        isValidInteger = false;
                        break;
                    }
                }

                previous = digit;
                i = i / 10;
            }

            return isValidInteger;
        }

        public static int[] Solution2(int N, int K) {
            List<int> integers = new List<int>{0, 1, 2, 3, 4, 5, 6, 7, 8, 9};

            for (int i = 2; i <= N; ++i) {
                List<int> tempIntegers = new List<int>();
                foreach(int integer in integers) {
                    int digit = integer % 10;
                    
                    if(integer > 0 && digit + K < 10)
                        tempIntegers.Add(integer * 10 + digit + K);
                    if(integer > 0 && K > 0 && digit - K >= 0)
                        tempIntegers.Add(integer * 10 + digit - K);
                }
                integers = tempIntegers;
            }          

            return integers.ToArray();
        }
    }
}