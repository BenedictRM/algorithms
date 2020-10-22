// Binary search is a search algorithm usually used on a sorted sequence to quickly find an element with a given value. In this problem we will evaluate how binary search performs on data that isn't necessarily sorted. An element is said to be binary searchable if an element can be found provided the pivot is chosen everytime as the middle element - like in a regular binary search.
// We need to find total number of elements which are binary searchable.

// Example 1:

// [2, 1, 3, 4, 6, 5] - 3 is searchable, 2 is searchable, 1 not searchable, 6 is searchable, 4 is seachable, 5 is not searchable 
// Output: 4

namespace algorithms
{
    public class BinarySearchableElems
    {
        public static int BinarySearchable(int[] arr){
            int count = binarySearch(arr, 0, arr.Length - 1, arr[(arr.Length - 1)/2]);

            return count;
        }

        private static int binarySearch(int[] arr, int left, int right, int lim) {
            int count = 0;
            int pivot = (left + right) / 2;

            if(left > right || left < 0 || right > arr.Length)
                return count;

            if(arr[pivot] <= lim) {
                count++;
                count += binarySearch(arr, left, pivot, arr[pivot]);
            } 
            // else if(arr[pivot] >= lim) {
            //     count++;
            //     count += binarySearch(arr, pivot + 1, right, arr[pivot]);
            // }

            return count;
        }
    }
}