using System;
using System.Collections.Generic;

namespace algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            // [5,10,-5]
            // [5,10,-50]
            // [5,10,-50,5,-10]
            // [8,-8]
            // [50, 10, -11, -60]
            // [50, 10, -11, -12]
            // [7,4]
            // [8,4,3,2,1,-1,-2,-3,-4,-5,-6,-7,-8]
            // [-2,-2,-2,-2]
            // [-2,-2,-1,-2]
            // [-2,-2,1,-1]
            // [-2,-1,1,2]
            // [-2,-1,1,-1] //-2,-1 ans
            int[] asteroids = new int[]{-2,-1,1,-1};

            AsteroidCollision ac = new AsteroidCollision();
            int[] survivors = ac.Solution(asteroids);

            foreach(int i in survivors)
                Console.Write("{0}, ", i);
        }

        //TODO: This is incomplete
        private static void runBinarySearchable(){
            // int[] arr = new int[]{2,1,3,4,6,5};
            int[] arr = new int[]{1,3,2};
            int count = BinarySearchableElems.BinarySearchable(arr);
            Console.WriteLine("Searchable Elements Are {0}", count);
        }

        private static void runIsWordBreakPossible(){
            //true
            // string s = "leetcode"; 
            // List<string> wordDict = new List<string>(){"leet", "code"};
            // //true
            // string s = "applepenapple"; 
            // List<string> wordDict = new List<string>(){"apple", "pen"};
            // //false
            string s = "catsandog"; 
            List<string> wordDict = new List<string>(){"cats", "dog", "sand", "and", "cat"};

            bool isPossible = WordBreak.IsWordBreakPossible(s, wordDict);
            Console.WriteLine("Is Possible: {0}", isPossible);
        }

        private static void runSubarrayProductLessThanK() {
            int[] nums = new int[]{10, 5, 2, 6}; 
            int k = 100;

            int total = SubarrayProductLessThanK.NumSubarrayProductLessThanK(nums, k);

            Console.WriteLine("Total Subarrays {0}", total);
        }

        private static void runEvaluateDivision() {
            //Test 1
            // IList<IList<string>> equations = new List<IList<string>>();
            // equations.Add(new List<string>(){"a","b"});
            // equations.Add(new List<string>(){"b","c"});

            // double[] values = new double[]{2.0,3.0};

            // IList<IList<string>> queries = new List<IList<string>>();
            // queries.Add(new List<string>(){"a","c"}); // 6.0
            // queries.Add(new List<string>(){"b","a"}); // 0.5
            // queries.Add(new List<string>(){"a","e"}); // -1.0
            // queries.Add(new List<string>(){"a","a"}); // 1.0
            // queries.Add(new List<string>(){"x","x"}); // - 1.0

            //Test 2
            IList<IList<string>> equations = new List<IList<string>>();
            equations.Add(new List<string>(){"a","b"});
            equations.Add(new List<string>(){"b","c"});
            equations.Add(new List<string>(){"bc","cd"});

            double[] values = new double[]{1.5,2.5,5.0};

            IList<IList<string>> queries = new List<IList<string>>();
            queries.Add(new List<string>(){"a","c"}); // 3.75
            queries.Add(new List<string>(){"c","b"}); // 0.4
            queries.Add(new List<string>(){"bc","cd"}); // 5.0
            queries.Add(new List<string>(){"cd","bc"}); // 0.2
            
            double[] answers = EvaluateDivision.CalcEquation(equations, values, queries);

            foreach(double answer in answers) {
                Console.WriteLine("Answer: {0}", answer);
            }
        }

        private static void runLargestNumber() {
            //Test cases
            int[] nums = new int[]{10,2};
            // [3,30,34,5,9]
            // []
            // [5]
            // [3,30,300]
            // [734,89345,3,5,89,99,100,2004,1000]
            // [121,12]
            // [0,9,8,7,6,5,4,3,2,1]
            // [0,0]
            // [0,0,3]
            // [0,0,0,0,0,0,0,0]
            // [824,938,1399,5607,6973,5703,9609,4398,8247]
            // [1440,7548,4240,6616,733,4712,883,8,9576]
            // [4704,6306,9385,7536,3462,4798,5422,5529,8070,6241,9094,7846,663,6221,216,6758,8353,3650,3836,8183,3516,5909,6744,1548,5712,2281,3664,7100,6698,7321,4980,8937,3163,5784,3298,9890,1090,7605,1380,1147,1495,3699,9448,5208,9456,3846,3567,6856,2000,3575,7205,2697,5972,7471,1763,1143,1417,6038,2313,6554,9026,8107,9827,7982,9685,3905,8939,1048,282,7423,6327,2970,4453,5460,3399,9533,914,3932,192,3084,6806,273,4283,2060,5682,2,2362,4812,7032,810,2465,6511,213,2362,3021,2745,3636,6265,1518,8398]

            LargestNumber.Largest(nums);
        }

        private static void runFindTheDifference() {
            // string s = "abcd";
            // string t = "abcde";
            string s = "abcdzfge";
            string t = "abcdezfga";
            char c = FindtheDifference.FindTheDifference(s, t);

            Console.WriteLine("Difference: {0} ", c);
        }

        private static void runCarPooling() {
            // int capacity = 11;
            // int[][] trips = new int[3][];
            // trips[0] = new int[3]{3,2,7};
            // trips[1] = new int[3]{3,7,9};
            // trips[2] = new int[3]{8,3,9};

            //Drop off points exist between stops -- ans: true
            // int capacity = 11;
            // int[][] trips = new int[3][];
            // trips[0] = new int[3]{3,2,8};
            // trips[1] = new int[3]{4,4,6};
            // trips[2] = new int[3]{10,8,9};

            // multiple trips with the same pickup location -- ans: false
            int capacity = 12;
            int[][] trips = new int[5][];
            trips[0] = new int[3]{8,2,3};
            trips[1] = new int[3]{4,1,3};
            trips[2] = new int[3]{1,3,6};
            trips[3] = new int[3]{8,4,6};
            trips[4] = new int[3]{4,4,8};

            bool isPossible = CarPooling.isPossible(trips, capacity);

            Console.WriteLine("is possible? {0}", isPossible);
        }

        private static void runMaximumProductSubarray() {
            int[] nums = new int[]{-2,2,3,-1,0,8,19,20,-1,47,5};
            // int[] nums = new int[]{-2,2,3,-1,0,8,19,20};
            int max = MaximumProductSubarray.MaxProduct(nums);

            Console.WriteLine("max is {0}", max);
        }

        private static void runBullsAndCows() {
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
