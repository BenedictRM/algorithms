using System;
using System.Collections.Generic;

namespace algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            string secret = "1123";
            string guess = "0111";
            string hint = BullsAndCows.GetHint(secret, guess);
            Console.WriteLine(hint);
        }

        private static void runRpeatedSubstringPattern() {
            // string s = "abab";//true
            // string s = "aaa";
            // string s = "aba";//false
            // string s = "abcabcabcabc";
            // string s = "abcabcabc";
            // string s = "abcabcabcdd";//false
            // string s = "abcabzcabc";//false
            // string s = "abac";//false
            // string s = "abacabac";//true
            string s = "abacababacab";//true
            bool isRepeated = RepeatedSubstringPattern.RepeatedSubstring(s);

            Console.WriteLine("Is Repeated: {0}", isRepeated);
        }

        //This solution is iterative, TODO: try solving recursively!
        private static void runNumberOfIslands() {
            // char[][] grid = new char[][]{
            //     new char[]{'1','1','1','1','0'},
            //     new char[]{'1','1','0','1','0'},
            //     new char[]{'1','1','0','0','0'},
            //     new char[]{'0','0','0','0','0'}
            // };//1

            // char[][] grid = new char[][]{
            //     new char[]{'0','0','0','0','0'},
            //     new char[]{'0','0','0','1','1'},
            //     new char[]{'0','1','0','1','1'},
            //     new char[]{'0','1','1','1','1'}
            // };//1

            char[][] grid = new char[][]{
                new char[]{'1','1','0','0','0'},
                new char[]{'1','1','0','0','0'},
                new char[]{'0','0','1','0','0'},
                new char[]{'0','0','0','1','1'}
            };//3

            int numIslands = NumberofIslands.NumIslands(grid);
            Console.WriteLine("Islands: {0}", numIslands);
        }

        private static void runLargestTimeForGivenDigit() {
            // int[] digits = new int[]{1,2,3,4};
            // int[] digits = new int[]{4,3,2,1};
            // int[] digits = new int[]{5,5,5,5};//invlaid
            // int[] digits = new int[]{1,9,9,1};
            // int[] digits = new int[]{1,9,2,5};
            // int[] digits = new int[]{1,7,6,9}; //invalid
            // int[] digits = new int[]{1,5,6,9}; //valid 19:56
            // int[] digits = new int[]{5,0,1,9}; //valid 19:50
            // int[] digits = new int[]{0,0,1,2}; //valid 21:00
            // int [] digits = new int[]{4,0,1,2};
            int [] digits = new int[]{2,0,6,6};

            string time = LargestTimeForGivenDigit.Solution(digits);

            Console.WriteLine(time);
        }

        private static void runRand10() {
            int ans = Rand10.Solution();

            Console.WriteLine("Answer: {0}", ans);
        }

        private static void runFindRightInterval() {
            int[][] intervals = new int[][]{
                new int[]{4,5},
                new int[]{2,3},
                new int[]{1,2}
            }; //should be -1,0,1

            int[] indexes = FindRightInterval.Solution2(intervals);

            foreach(int i in indexes) {
                Console.WriteLine("Index: {0}", i);
            }
        }

        private static void runMinimumCostForTickets() {
            // int[] days = new int[]{1,4,6,7,8,20}; 
            // int[] days = new int[]{1,2,3,4,5,6,7,8,9,10,30,31}; 
            // int[] days = new int[]{1,4,6,9,10,11,12,13,14,15,16,17,18,20,21,22,23,27,28};
            // int[] costs = new int[]{2,7,15};
            // int[] costs = new int[]{3,13,45};

            // int[] days = new int[]{1,2,4,5,6,9,10,12,14,15,18,20,21,22,23,24,25,26,28}; // ans: 45
            // int[] costs = new int[]{3,13,57};

            int[] days = new int[]{1,4,6,7,8,20}; //ans: 6
            int[] costs = new int[]{7,2,15};
            
            int total = MinimumCostForTickets.Solution(days, costs);

            Console.WriteLine("Total was: {0}", total);
        }

        private static void runStreamhecker() {
            StreamChecker streamChecker = new StreamChecker(new string[]{"cd","f","kl"}); // init the dictionary.
            Console.WriteLine(streamChecker.Query('a'));          // return false
            Console.WriteLine(streamChecker.Query('b'));          // return false
            Console.WriteLine(streamChecker.Query('c'));          // return false
            Console.WriteLine(streamChecker.Query('d'));          // return true, because 'cd' is in the wordlist
            Console.WriteLine(streamChecker.Query('e'));          // return false
            Console.WriteLine(streamChecker.Query('f'));          // return true, because 'f' is in the wordlist
            Console.WriteLine(streamChecker.Query('g'));          // return false
            Console.WriteLine(streamChecker.Query('h'));          // return false
            Console.WriteLine(streamChecker.Query('i'));          // return false
            Console.WriteLine(streamChecker.Query('j'));          // return false
            Console.WriteLine(streamChecker.Query('k'));          // return false
            Console.WriteLine(streamChecker.Query('l'));          // return true, because 'kl' is in the wordlist
        }

        private static void runSortArrayByParity() {
            int[] A = new int[]{6,3,1,2,4,5,7,9};
            SortArrayByParity.Solution(A);

            foreach(int i in A)
                Console.WriteLine(i);
        }

        private static void runReorderList() {
             ListNode head = buildList(6);
            
            ReorderList.Solution(null);

            Console.WriteLine("Solution");
            printList(head);
        }

        private static ListNode buildList(int size = 1) {
            ListNode head = new ListNode(1);
            ListNode list = head;

            for(int i = 2; i < size + 1; i++){
                head.next = new ListNode(i);
                head = head.next;
            }

            head = list;

            printList(head);

            return head;
        }

        private static void printList(ListNode head) {
            while(head != null) {
                Console.WriteLine("Node Value: " + head.val);
                head = head.next;
            }
        }

        private static void runToGoatLatin() {
            string s = "I speak Goat Latin";
            string translation = GoatLatin.ToGoatLatin(s);

            Console.WriteLine("translated {0} to: {1}", s, translation);
        }

        private static void runNumbersWithSameConsecutiveDifferences() {
            int N = 3;
            int K = 7;
            int[] integers = NumbersWithSameConsecutiveDifferences.Solution2(N, K);
            
            Console.WriteLine("Integers of length {0} and consecutive difference of {1}:", N, K);

            foreach(int i in integers) {
                Console.WriteLine(i);
            }
        }

        private static void runDistrbuteCandies() {
            int candies = 80;
            int people = 4; 

            int[] distribution = DistributeCandies.Solution(candies, people);

            Console.WriteLine("Distribution is: ");
            foreach(int i in distribution) {
                Console.WriteLine(i);
            }
        }

        private static void runBigO(int remaining) {
            bigO problem11 = new bigO();

            problem11.printSortedStrings(remaining);
        }

        private static void runStringManipulation() {
            String reverseMe = "Reverse Me";

            StringManipulation.ReverseStringBuiltIn(reverseMe);
            StringManipulation.ReverseString(reverseMe);
            StringManipulation.ReverseStringArrayList(reverseMe);
        }

        private static void runHashtable() {
            HashTable h = new HashTable();
        }

        private static void runBinarySearchTree() {
            int nodeToRemove = 5;

            Console.WriteLine("Creating Binary Search Tree");
            List<int> values = new List<int>{5,2,9,45,3,1};
            BinarySearchTree bst = new BinarySearchTree(values);

            bst.PrintTreeToConsole();

            Console.WriteLine("Removing Node: " + nodeToRemove);
            bst.RemoveNode(nodeToRemove);
            bst.PrintTreeToConsole();
        }
    }
}
