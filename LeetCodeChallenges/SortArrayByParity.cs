// Given an array A of non-negative integers, return an array consisting of all the even elements of A, followed by all the odd elements of A.
// You may return any answer array that satisfies this condition.

// Example 1:
// Input: [3,1,2,4]
// Output: [2,4,3,1]
// The outputs [4,2,3,1], [2,4,1,3], and [4,2,1,3] would also be accepted.

// Note:
// 1. 1 <= A.length <= 5000
// 2. 0 <= A[i] <= 5000

namespace algorithms
{
    public class SortArrayByParity
    {
        // public static int[] Solution(int[] A) {
        //     int start = 0;
        //     int end = A.Length - 1;

        //     //possibly <=
        //     while(start < end) {
        //         while(A[start] % 2 == 0 && start < end)
        //             start++;
        //         while(A[end] % 2 != 0 && end > start)
        //             end--; 
        //         if(start < end) {
        //             A[start] += A[end];
        //             A[end] = A[start] - A[end];
        //             A[start] -= A[end];

        //             start++;
        //             end--;
        //         }
        //     }
        //     return A;
        // }

        //Fastest ans (not mine)
        public static int[] Solution(int[] A) {
            int start = 0;
            int end = A.Length-1;
              
            while(start < end){
                if((A[start] % 2) == 0){
                    start++;
                }
                else {
                    int temp = A[end];
                    A[end] = A[start];
                    A[start] = temp;
                    end--;
                }
            }

            return A;
        }
    }
}