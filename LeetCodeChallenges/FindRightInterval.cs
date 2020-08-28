using System;
using System.Collections.Generic;

namespace algorithms
{
    public class FindRightInterval
    {
        public static int[] Solution2(int[][] intervals) {
            int[] indexes = new int[intervals.Length];
            //store original index locations before sorting
            var intervalStartByMinIdx = new Dictionary<int, int>();

            for (int i = 0; i < intervals.Length; i++) {
                int key = intervals[i][0];

                intervalStartByMinIdx.Add(key, i);
                //store rightInterval so search order remains same
                indexes[i] = intervals[i][1];
            }

            quicksort(intervals, 0, intervals.Length - 1);

            for (int i = 0; i < intervals.Length; i++) {
                int lastIdx = intervals[i].Length - 1;
                int rightInterval = indexes[i];

                int val = binarysearch(intervals, rightInterval);
                indexes[i] = val == int.MinValue ? -1 : intervalStartByMinIdx[val];
            }

            return indexes;
        }

        private static void quicksort(int[][] intervals, int left, int right) {
            int index = partition(intervals, left, right);

            if(left < index - 1)
                quicksort(intervals, left, index - 1); 
            if(index < right)
                quicksort(intervals, index, right); 
        }

        private static int partition(int[][] intervals, int left, int right) {
            int pivot = intervals[(left + right) / 2][0];

            while(left <= right) {
                while(intervals[left][0] < pivot) left++;
                while(intervals[right][0] > pivot) right--;

                if(left <= right) {
                    int[] temp = intervals[left];
                    intervals[left] = intervals[right];
                    intervals[right] = temp;
                    left++;
                    right--;
                }
            }

            return left;
        }

        private static int binarysearch(int[][] intervals, int target){
            int index = int.MinValue;
            int low = 0;
            int high = intervals.Length - 1;

            while(low <= high) {
                int mid = (low + high) / 2;
                int value = intervals[mid][0];

                if(value == target){
                    index = value;
                    break;
                } else if(value < target) {
                    low = mid + 1;
                } else {
                    index = value;
                    high = mid - 1;
                }
            }

            return index;
        }

        public static int[] Solution(int[][] intervals) {
            var intervalStartByMinIdx = new Dictionary<int, int>();
            int[] indexes = new int[intervals.Length];
            int max = 0;

            for (int i = 0; i < intervals.Length; i++) {
                int key = intervals[i][0];
                max = Math.Max(max, key);

                if(!intervalStartByMinIdx.ContainsKey(key))
                    intervalStartByMinIdx.Add(key, i);
            }

            for (int i = 0; i < intervals.Length; i++) {
                int lastIdx = intervals[i].Length - 1;
                int rightInterval = intervals[i][lastIdx];

                indexes[i] = -1;

                while(rightInterval <= max) {
                    if(intervalStartByMinIdx.ContainsKey(rightInterval)) {
                        indexes[i] = intervalStartByMinIdx[rightInterval];
                        break;
                    }

                    rightInterval++;
                }
            }

            return indexes;
        }
    }
}