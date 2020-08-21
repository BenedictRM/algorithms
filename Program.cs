using System;
using System.Collections.Generic;

namespace algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
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
