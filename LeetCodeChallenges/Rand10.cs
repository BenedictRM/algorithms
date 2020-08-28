// Given a function rand7 which generates a uniform random integer in the range 1 to 7, write a function rand10 which generates a uniform random integer in the range 1 to 10.

// Do NOT use system's Math.random().

// Example 1:
// Input: 1
// Output: [7]

// Example 2:
// Input: 2 //call rand7() twice, thus 2 numbers
// Output: [8,4]

// Example 3:
// Input: 3
// Output: [8,1,10]

// Note:
// rand7 is predefined.
// Each testcase has one argument: n, the number of times that rand10 is called.


//Solution uses rejection sampling: https://studyalgorithms.com/array/given-a-function-that-generates-random-number-from-1-7-write-a-function-that-generates-random-numbers-from-1-10/
namespace algorithms
{
    public class Rand10
    {
        /**
        * The Rand7() API is already defined in the parent class SolBase.
        * public int Rand7();
        * @return a random integer in the range 1 to 7
        */
        public static int Solution() {
            int rand = 40;
        
            while(rand >= 40)
            rand = ((Rand7() - 1) * 7) + (Rand7() - 1);   
        

            return ((rand % 10) + 1);
        }
    }
}