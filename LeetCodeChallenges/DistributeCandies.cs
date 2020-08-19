using System;

namespace algorithms
{
// We distribute some number of candies, to a row of n = num_people people in the following way:
// We then give 1 candy to the first person, 2 candies to the second person, and so on until we give n candies to the last person.
// Then, we go back to the start of the row, giving n + 1 candies to the first person, n + 2 candies to the second person, and so on until we give 2 * n candies to the last person.
// This process repeats (with us giving one more candy each time, and moving to the start of the row after we reach the end) until we run out of candies.  The last person will receive all of our remaining candies (not necessarily one more than the previous gift).
// Return an array (of length num_people and sum candies) that represents the final distribution of candies

//Example
// Input: candies = 7, num_people = 4
// Output: [1,2,3,1]
// Explanation:
// On the first turn, ans[0] += 1, and the array is [1,0,0,0].
// On the second turn, ans[1] += 2, and the array is [1,2,0,0].
// On the third turn, ans[2] += 3, and the array is [1,2,3,0].
// On the fourth turn, ans[3] += 1 (because there is only one candy left), and the final array is [1,2,3,1].
    public class DistributeCandies
    {
        public static int[] Solution(int candies, int num_people) {
            int[] distribution = new int[num_people];
            int candiesRequired  = 0;

            if(candies > sum(num_people)){
                int n = num_people;
                if(sum(n + num_people) < candies) {
                    n += num_people;
                }
                candiesRequired = n;
                while(n > 0) {
                    for(int i = distribution.Length - 1; i >= 0; i--) {
                        distribution[i] += n;
                        candies -= n;
                        n--;
                    }
                }
                
                foreach(int i in distribution) {
                    Console.WriteLine(i);
                }
            } 

            candiesRequired += 1;

            //Distrubte remaining candies
            while(candies > 0) {
                for(int i = 0; i < distribution.Length; i++) {
                    if(candies <= 0)
                        break;
                    
                    if(candiesRequired > candies) {
                        distribution[i] = distribution[i] + candies;
                        candies = 0;
                    }
                    else {
                        distribution[i] = distribution[i] + candiesRequired;
                        candies -= candiesRequired;
                    }

                    candiesRequired++;
                }
            }

            // Console.WriteLine("** remaining: " + candies);

            return distribution;
        }

        private static int sum(int n) {
            int sum = (n * (n + 1))/2;

            return sum;
        }
    }
}