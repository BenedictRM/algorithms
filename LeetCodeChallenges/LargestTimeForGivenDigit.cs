// Given an array of 4 digits, return the largest 24 hour time that can be made.

// The smallest 24 hour time is 00:00, and the largest is 23:59.  Starting from 00:00, a time is larger if more time has elapsed since midnight.

// Return the answer as a string of length 5.  If no valid time can be made, return an empty string.

// Example 1:

// Input: [1,2,3,4]
// Output: "23:41"
// Example 2:

// Input: [5,5,5,5]
// Output: ""
using System;
using System.Linq;
using System.Text;

namespace algorithms
{
    public class LargestTimeForGivenDigit
    {
        public static string Solution(int[] A) {
            string time = string.Empty;
            Array.Sort(A);

            //must be invalid if no integers < 2 are in the array
            if(A[0] > 2)
                return string.Empty;

            for(int i = 0; i < A.Length; i++) {
                if(i == 0 && A[i] <= 2)
                    continue;
                Console.WriteLine("Checking arr pos {0} with array state {1}", i, string.Join("", A.Select(x => x.ToString()).ToArray()) );
                if(A[i] <= 2 && (A[i] > A[0] || A[0] > 2)) {
                    swap(A, i, 0);
                } 
                else if((A[i] <= 3 && A[0] == 2 && (A[i] > A[1] || A[1] > 3)) || (A[i] > A[1] && A[0] < 2)) {
                    swap(A, i, 1);
                } 
                else if(A[i] <= 5 && (A[i] > A[2] || A[2] > 5)) {
                    swap(A, i, 2);
                } 
            }

            if(A[2] < A[3] && A[3] < 6)
                swap(A,2,3);

            if(A[1] < A[2] && (A[2] < 4 && A[0] == 2 || A[0] < 2))
                swap(A,1,2);
            
            if(A[1] < A[3] && (A[3] < 4 && A[0] == 2 || A[0] < 2))
                swap(A,1,3);

            if(isValid(A)) {
                StringBuilder builder = new StringBuilder();
                builder.Append(A[0]);
                builder.Append(A[1]);
                builder.Append(":");
                builder.Append(A[2]);
                builder.Append(A[3]);

                time = builder.ToString();
            }

            return time;
        }

        private static void swap(int[] A, int i, int j) {
            A[i] = A[i] + A[j];
            A[j] = A[i] - A[j];
            A[i] = A[i] - A[j];
        }

        private static bool isValid(int[] A) {
            bool isValid = true;

            if(int.Parse(string.Join("", A.Select(x => x.ToString()).ToArray())) > 2359)
                isValid = false;
            else if(A[2] > 5 || (A[0] == 2 && A[1] > 3))
                isValid = false;
            
            return isValid;
        }
    }
}