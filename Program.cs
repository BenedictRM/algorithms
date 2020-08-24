using System;
using System.Collections.Generic;

namespace algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
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
