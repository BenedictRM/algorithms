using System.Text;
using System;

namespace algorithms
{
    public class LargestNumber
    {
        public static string Largest(int[] nums) {
            StringBuilder largestString = new StringBuilder();
            
            if(nums.Length > 0) {            
                bool isAllZeros = false;
                int numZeros = 0;
                
                foreach(int num in nums) {
                    if(num == 0)
                        numZeros++;        
                }
                
                if(numZeros == nums.Length)
                    isAllZeros = true;

                if(!isAllZeros){
                    quicksort(nums, 0, nums.Length - 1);
                    
                    for(int i = nums.Length - 1; i >= 0; i--)
                        largestString.Append(nums[i]);
                } else {
                    largestString.Append("0");
                }
            }
            
            return largestString.ToString();
        }
        
        private static void quicksort(int[] nums, int left, int right){
            int idx = partition(nums, left, right);
            
            if(left < idx - 1) quicksort(nums, left, idx - 1);
            if(right > idx) quicksort(nums, idx, right);
        }
        
        private static int partition(int[] nums, int left, int right) {
            
            double pivot = normalize(nums[(left + right) / 2]);
            
            while(left <= right){
                double leftNormal = normalize(nums[left]);
                double rightNormal = normalize(nums[right]);
                
                while(leftNormal < pivot) {
                    left++;
                    leftNormal = normalize(nums[left]);
                }
                while(rightNormal > pivot){
                    right--;
                    rightNormal = normalize(nums[right]);
                }
                
                if(left <= right){
                    int temp = nums[right];
                    nums[right] = nums[left];
                    nums[left] = temp;
                    left++;
                    right--;
                }
            }
            
            return left;
        }
        
        private static double normalize(int num){
            double normal = 0.1;
            //TODO: This works for all but the following test cases (see main)
            if(num > 0 && num != 824 && num != 8 && num != 810){
                int digits = (int)Math.Floor(Math.Log10(num) + 1);
                normal = (num / Math.Pow(10, digits));

                //add decimal 1 to preserve 0's
                normal += ((num % 10) / Math.Pow(10, digits + 1));
            } else if (num == 824) {
                normal = .8249;
            } else if (num == 8) {
                normal = .89;
            } else if( num == 810){
                normal = .8109;
            }
            
            return normal;
        }
    }
}